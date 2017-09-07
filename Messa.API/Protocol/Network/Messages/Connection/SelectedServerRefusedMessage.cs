﻿namespace Messa.API.Protocol.Network.Messages.Connection
{
    using Utils.IO;

    public class SelectedServerRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 41;
        public override ushort MessageID => ProtocolId;
        public ushort ServerId { get; set; }
        public byte Error { get; set; }
        public byte ServerStatus { get; set; }

        public SelectedServerRefusedMessage(ushort serverId, byte error, byte serverStatus)
        {
            ServerId = serverId;
            Error = error;
            ServerStatus = serverStatus;
        }

        public SelectedServerRefusedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
            writer.WriteByte(Error);
            writer.WriteByte(ServerStatus);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
            Error = reader.ReadByte();
            ServerStatus = reader.ReadByte();
        }

    }
}
