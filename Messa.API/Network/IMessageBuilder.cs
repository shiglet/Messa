using Messa.API.Protocol;
using Messa.API.Utils.IO;

namespace Messa.API.Network
{
    public interface IMessageBuilder
    {
        NetworkMessage BuildMessage(ushort messageid, IDataReader reader);
    }
}