﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Gamedata;
using Messa.API.Messages;
using Messa.API.Network;
using Messa.API.Protocol;
using Messa.API.Protocol.Enums;
using Messa.API.Protocol.Network.Messages.Connection;
using Messa.API.Protocol.Network.Messages.Game.Approach;
using Messa.API.Protocol.Network.Messages.Game.Character.Choice;
using Messa.API.Protocol.Network.Messages.Queues;
using Messa.API.Protocol.Network.Messages.Security;
using Messa.API.Protocol.Network.Types.Version;
using Messa.API.Utils;
using Messa.API.Utils.Cryptography;
using Messa.API.Utils.Enums;
using Messa.API.Utils.Extensions;
using Messa.Core;

namespace Messa.FullSocket
{
    public class FullSocket
    {
        public static int ServerConnectionTimeout = 4000;

        private readonly FullSocketConfiguration _mConfiguration;

        private readonly Dictionary<string, Tuple<IAccount, SelectedServerDataMessage>> _mTickets =
            new Dictionary<string, Tuple<IAccount, SelectedServerDataMessage>>();

        private readonly List<ConnectionFullSocket> _servers = new List<ConnectionFullSocket>();

        public FullSocket(FullSocketConfiguration configuration, MessageReceiver messageReceiver)
        {
            _mConfiguration = configuration;

            MessageBuilder = messageReceiver;
        }

        public ClientManager<ConnectionFullSocket> AuthConnection { get; set; }

        public MessageReceiver MessageBuilder { get; set; }

        public IAccount Connect(string username, string password)
        {
            var server = new ConnectionFullSocket(new ServerConnection(MessageBuilder), MessageBuilder);

            server.Disconnected += OnAuthClientDisconnected;
            server.MessageReceived += OnAuthClientMessageReceived;

            var dispatcher = new NetworkMessageDispatcher { Server = server };

            server.Account = new Account(username, password, server, dispatcher)
            {
                Network = { ConnectionType = ClientConnectionType.Authentification }
            };

            server.Account.Network.RegisterPacket<HelloConnectMessage>(HandleHelloConnectMessage,
                MessagePriority.VeryHigh);

            server.Account.Network.RegisterPacket<ServersListMessage>(HandleServersListMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<SelectedServerDataMessage>(HandleSelectedServerDataMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<RawDataMessage>(HandleRawDataMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<SelectedServerDataExtendedMessage>(
                HandleSelectedServerDataExtendedMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<IdentificationFailedBannedMessage>(
                HandleIdentificationFailedBannedMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<IdentificationFailedMessage>(HandleIdentificationFailedMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<SelectedServerRefusedMessage>(HandleSelectedServerRefusedMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<LoginQueueStatusMessage>(HandleLoginQueueStatusMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<QueueStatusMessage>(HandleQueueStatusMessage,
                MessagePriority.VeryHigh);
            // Connection FullSocket BindingToServer
            server.Account.Network.Start();
            server.BindToServer(_mConfiguration.RealAuthHost, _mConfiguration.RealAuthPort);

            _servers.Add(server);
            return server.Account;
        }

        private static void HandleRawDataMessage(IAccount account, RawDataMessage message)
        {
            var tt = new List<sbyte>();
            for (var i = 0; i <= 255; i++)
            {
                var random = new Random();
                var test = random.Next(-127, 127);
                tt.Add((sbyte)test);
            }
            var rawData = new CheckIntegrityMessage(tt);
            account.Network.SendToServer(rawData);
        }

        private void OnAuthClientDisconnected(Client client)
        {
            var fs = client as ConnectionFullSocket;
            fs.Account.Network.AddMessage(() =>
            {
                if (fs.Account.Network.ExpectedDisconnection)
                {
                    fs.Account.Network.ExpectedDisconnection = false;

                    // Need to free event for recursive call
                    fs.Disconnected -= OnAuthClientDisconnected;
                    fs.MessageReceived -= OnAuthClientMessageReceived;

                    fs.Account.Network.Stop();

                    var ticket = fs.Account.Ticket;
                    var tuple = _mTickets[ticket];
                    _mTickets.Remove(ticket);

                    // Reconnect to selected server
                    fs.Account.Network.Start();

                    // Handle Message on World Client
                    fs.Disconnected += OnWorldClientDisconnected;
                    fs.MessageReceived += OnWorldClientMessageReceived;
                    try
                    {
                        fs.Server.Reconnect(tuple.Item2.Address, tuple.Item2.Port);
                    }
                    catch (Exception ex)
                    {
                        fs.Account.Network.Stop();
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    fs.Account.Network.Dispose();
                }
            });
        }

        private static void OnWorldClientDisconnected(Client client)
        {
            var fs = client as ConnectionFullSocket;
            fs.Account.Logger.Log("Client deconnecté !");
            fs?.Account.Network?.AddMessage(fs.Account.Network.Dispose);
        }

        private void OnAuthClientMessageReceived(Client client, NetworkMessage message)
        {
            if (!(client is ConnectionFullSocket))
                throw new ArgumentException("client is not of type ConnectionFullSocket");

            var fs = (ConnectionFullSocket)client;
            if (message is IdentificationSuccessMessage ism)
                HandleIdentificationSuccessMessage(fs, ism);
            if (message is SelectedServerDataMessage ssdm)
            {
                var msg = ssdm;

                fs.Account.Logger.Log("Sélection du serveur " + D2OParsing.GetServerName(msg.ServerId));
                var ticket = AES.DecodeWithAES(msg.Ticket);
                _mTickets.Add(ticket,
                    Tuple.Create(fs.Account,
                        new SelectedServerDataMessage(msg.ServerId, msg.Address, msg.Port, msg.CanCreateNewCharacter,
                            msg.Ticket)));
                fs.Account.Ticket = ticket;
            }
            if (fs.Account.Network == null)
                throw new NullReferenceException("fs.Bot");
            fs.Account.Network.Dispatcher.Enqueue(message, fs.Account);
        }

        private void OnWorldClientMessageReceived(Client client, NetworkMessage message)
        {
            if (!(client is ConnectionFullSocket))
                throw new ArgumentException("client is not of type ConnectionFullSocket");

            var fs = (ConnectionFullSocket)client;

            if (message is HelloGameMessage)
            {
                var timer = ((ConnectionFullSocket)fs.Account.Network.Connection).TimeOutTimer;
                timer?.Dispose();

                fs.SendToServer(new AuthenticationTicketMessage("fr", fs.Account.Ticket));
            }

            if (message is AuthenticationTicketAcceptedMessage)
            {
                // special handling to connect and retrieve the bot instance
                fs.Account.Network.ConnectionType = ClientConnectionType.GameConnection;
                fs.SendToServer(new CharactersListRequestMessage());
            }
            else
            {
                if (fs.Account.Network == null)
                    throw new NullReferenceException("fs.Bot");

                if (fs.Account.Network.Dispatcher.Stopped)
                    throw new Exception("Enqueue a message but the dispatcher is stopped !");

                fs.Account.Network.Dispatcher.Enqueue(message, fs.Account);
            }
        }

        private void HandleIdentificationSuccessMessage(ConnectionFullSocket client,
            IdentificationSuccessMessage message)
        {
            client.Account.Nickname = message.Login;
            client.Account.Logger.Log("Connecté");
        }

        private void HandleHelloConnectMessage(IAccount account, HelloConnectMessage message)
        {
            account.Network.ConnectionType = ClientConnectionType.Authentification;
            account.Logger.Log("Connecté au serveur d'authentification.");
            var credentials = Rsa.Encrypt(message.Key, account.Login, account.Password, message.Salt);
            var version = new VersionExtended
            {
                BuildType = GameConstant.BuildType,
                Install = GameConstant.Install,
                Major = GameConstant.Major,
                Minor = GameConstant.Minor,
                Patch = GameConstant.Patch,
                Release = GameConstant.Release,
                Revision = GameConstant.Revision,
                Technology = GameConstant.Technology
            };

            var identificationMessage =
                new IdentificationMessage(true, false, false, version, "fr", credentials, 0, 0, new List<ushort>());
            account.Logger.Log("Envois des informations d'identification...");
            account.Network.SendToServer(identificationMessage);
        }
        
        private void HandleServersListMessage(IAccount account, ServersListMessage message)
        {
            if (message.AlreadyConnectedToServerId != 0)
            {
                account.Network.SendToServer(new ServerSelectionMessage(message.AlreadyConnectedToServerId));
                return;
            }

            var server = message.Servers.Find(s => (ServerStatusEnum) s.Status == ServerStatusEnum.ONLINE
                                                   && s.IsSelectable && s.CharactersCount > 0);

            account.Network.SendToServer(server == null
                ? new ServerSelectionMessage(11)
                : new ServerSelectionMessage(server.ObjectId));
        }

        private void HandleSelectedServerDataMessage(IAccount account, SelectedServerDataMessage message)
        {
            var ticket = AES.DecodeWithAES(message.Ticket);
            var tuple = _mTickets[ticket];
            tuple.Item1.Network.ExpectedDisconnection = true;
            tuple.Item1.Ticket = ticket;
        }

        private void HandleSelectedServerDataExtendedMessage(IAccount account,
            SelectedServerDataExtendedMessage message)
        {
            HandleSelectedServerDataMessage(account, message);
        }

        private void HandleIdentificationFailedBannedMessage(IAccount account,
            IdentificationFailedBannedMessage message)
        {
            if (message.BanEndDate != 0)
                account.Logger.Log($"Votre compte est banni jusqu'au : {message.BanEndDate.UnixTimestampToDateTime()}.",
                    LogMessageType.Public);
            else
                account.Logger.Log("Votre compte est banni pour : " + message.Reason, LogMessageType.Public);
        }

        private void HandleIdentificationFailedMessage(IAccount account, IdentificationFailedMessage message)
        {
            account.Logger.Log($"Identification Fail -> {(IdentificationFailureReasonEnum)message.Reason}");
        }

        private void HandleLoginQueueStatusMessage(IAccount account, LoginQueueStatusMessage message)
        {
            if (message.Position != 0 && message.Total != 0)
                account.Logger.Log("Vous êtes en position " + message.Position + " sur " + message.Total +
                                   " dans la file d'attente.");
        }

        private void HandleQueueStatusMessage(IAccount account, QueueStatusMessage message)
        {
            if (message.Position != 0 && message.Total != 0)
                account.Logger.Log("Vous êtes en position " + message.Position + " sur " + message.Total +
                                   " dans la file d'attente.");
        }

        private void HandleSelectedServerRefusedMessage(IAccount account, SelectedServerRefusedMessage message)
        {
            switch ((ServerStatusEnum)message.ServerStatus)
            {
                case ServerStatusEnum.SAVING:
                    account.Logger.Log($"Le serveur séléctionné est en cours de sauvegarde.");
                    break;
                case ServerStatusEnum.FULL:
                    account.Logger.Log($"Le serveur séléctionné est plein.");
                    break;
            }
        }
    }
}
