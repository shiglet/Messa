﻿namespace Messa.API.Protocol.Network.Messages.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutBarRemoveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6228;
        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public byte Slot { get; set; }

        public ShortcutBarRemoveRequestMessage(byte barType, byte slot)
        {
            BarType = barType;
            Slot = slot;
        }

        public ShortcutBarRemoveRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteByte(Slot);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            Slot = reader.ReadByte();
        }

    }
}
