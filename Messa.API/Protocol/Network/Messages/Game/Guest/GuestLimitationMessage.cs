﻿namespace Messa.API.Protocol.Network.Messages.Game.Guest
{
    using Utils.IO;

    public class GuestLimitationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6506;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public GuestLimitationMessage(byte reason)
        {
            Reason = reason;
        }

        public GuestLimitationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
