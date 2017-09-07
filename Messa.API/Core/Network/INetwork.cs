using System;
using Messa.API.Messages;
using Messa.API.Network;
using Messa.API.Protocol;

namespace Messa.API.Core.Network
{
    public interface INetwork
    {
        ClientConnectionType ConnectionType { get; set; }

        bool ExpectedDisconnection { get; set; }

        MessageDispatcher Dispatcher { get; set; }

        IClient Connection { get; set; }

        event Action<IAccount, NetworkMessage> MessageReceived;
        event Action<IAccount, NetworkMessage> MessageSent;

        void RegisterPacket<T>(Action<IAccount, T> handler, MessagePriority priority) where T : Message;

        void SendToServer(NetworkMessage message, bool direct = false);
        void Disconnect();

        void Start();
        void Stop();

        void AddMessage(Action a);

        void Dispose();
    }
}