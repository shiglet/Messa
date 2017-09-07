﻿namespace Messa.API.Protocol.Network.Messages.Security
{
    using System.Collections.Generic;
    using Utils.IO;

    public class CheckIntegrityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6372;
        public override ushort MessageID => ProtocolId;
        public List<sbyte> Data { get; set; }

        public CheckIntegrityMessage(List<sbyte> data)
        {
            Data = data;
        }

        public CheckIntegrityMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(Data.Count);
            for (var dataIndex = 0; dataIndex < Data.Count; dataIndex++)
            {
                writer.WriteSByte(Data[dataIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var dataCount = reader.ReadVarInt();
            Data = new List<sbyte>();
            for (var dataIndex = 0; dataIndex < dataCount; dataIndex++)
            {
                Data.Add(reader.ReadSByte());
            }
        }

    }
}
