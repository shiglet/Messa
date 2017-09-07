﻿namespace Messa.API.Protocol.Network.Messages.Queues
{
    using Utils.IO;

    public class LoginQueueStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 10;
        public override ushort MessageID => ProtocolId;
        public ushort Position { get; set; }
        public ushort Total { get; set; }

        public LoginQueueStatusMessage(ushort position, ushort total)
        {
            Position = position;
            Total = total;
        }

        public LoginQueueStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Position);
            writer.WriteUShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Position = reader.ReadUShort();
            Total = reader.ReadUShort();
        }

    }
}
