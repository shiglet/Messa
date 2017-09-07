﻿namespace Messa.API.Protocol.Network.Messages.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutBarSwapRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6230;
        public override ushort MessageID => ProtocolId;
        public byte BarType { get; set; }
        public byte FirstSlot { get; set; }
        public byte SecondSlot { get; set; }

        public ShortcutBarSwapRequestMessage(byte barType, byte firstSlot, byte secondSlot)
        {
            BarType = barType;
            FirstSlot = firstSlot;
            SecondSlot = secondSlot;
        }

        public ShortcutBarSwapRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(BarType);
            writer.WriteByte(FirstSlot);
            writer.WriteByte(SecondSlot);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadByte();
            FirstSlot = reader.ReadByte();
            SecondSlot = reader.ReadByte();
        }

    }
}
