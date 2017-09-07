using Messa.API.Protocol;

namespace Messa.API.Network
{
    public interface IClient
    {
        void Send(NetworkMessage message);
        void Receive(byte[] buffer, int offset, int length);

        void Disconnect();
    }
}