using System;
using Messa.API.Utils.IO;

namespace Messa.API.Protocol
{
    public abstract class NetworkType : MarshalByRefObject
    {
        public abstract ushort TypeID { get; }

        public abstract void Serialize(IDataWriter writer);
        public abstract void Deserialize(IDataReader reader);
    }
}