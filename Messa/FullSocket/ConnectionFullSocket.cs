using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Network;
using Messa.API.Protocol;
using Messa.API.Utils.Extensions;

namespace Messa.FullSocket
{
    public class ConnectionFullSocket : Client
    {
        public ConnectionFullSocket(ServerConnection serverConnection, IMessageBuilder messageBuilder) :
            base(serverConnection.Socket)
        {
            MessageBuilder = messageBuilder;
            Server = serverConnection;
        }

        public string LastMessage { get; set; }

        public override IMessageBuilder MessageBuilder { get; }
        public IAccount Account { get; set; }

        public bool IsBoundToServer => Server != null && Server.IsConnected;

        public ServerConnection Server { get; }
        public SimplerTimer TimeOutTimer { get; set; }

        /// <summary>
        ///     Open a new connection and bind the client to the server
        /// </summary>
        public void BindToServer(string host, int port)
        {
            if (IsBoundToServer)
                throw new InvalidOperationException("Client already bound to server");

            Server.Connected += OnServerConnected;
            Server.Disconnected += OnServerDisconnected;
            Server.MessageReceived += OnServerMessageReceived;

            Server.Connect(host, port);
        }

        private void OnServerMessageReceived(ServerConnection server, NetworkMessage message)
        {
            message.From = ListenerEntry.Server;
            message.Destinations = ListenerEntry.Client | ListenerEntry.Local;

            LastMessage = message.GetType().ToString();
            base.OnMessageReceived(message);
        }

        private void OnServerDisconnected(ServerConnection server)
        {
            Disconnect();
        }

        private void OnServerConnected(ServerConnection server)
        {
            Console.WriteLine($@"Connected to Server {server.Ip}");
            Account.Logger.Log("Connexion en cours <" + server.Ip + ">");
        }

        protected override void OnMessageReceived(NetworkMessage message)
        {
            message.From = ListenerEntry.Client;
            message.Destinations = ListenerEntry.Server | ListenerEntry.Local;

            LastMessage = message.GetType().ToString();
            base.OnMessageReceived(message);
        }

        public void SendToServer(NetworkMessage message)
        {
            if (!IsBoundToServer)
                throw new InvalidOperationException("Client is not bound to server");

            Server.Send(message);
        }

        public override void Send(NetworkMessage message)
        {
            if (message.Destinations.HasFlag(ListenerEntry.Server))
                SendToServer(message);
            if (message.Destinations.HasFlag(ListenerEntry.Client))
                base.Send(message);
            else if (message.Destinations == ListenerEntry.Undefined)
                base.Send(message);
        }

        public override void Disconnect()
        {
            if (IsBoundToServer)
                Server.Disconnect();

            base.Disconnect();
        }
    }
}
