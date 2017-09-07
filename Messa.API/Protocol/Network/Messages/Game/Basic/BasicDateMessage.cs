﻿namespace Messa.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicDateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 177;
        public override ushort MessageID => ProtocolId;
        public byte Day { get; set; }
        public byte Month { get; set; }
        public short Year { get; set; }

        public BasicDateMessage(byte day, byte month, short year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public BasicDateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Day);
            writer.WriteByte(Month);
            writer.WriteShort(Year);
        }

        public override void Deserialize(IDataReader reader)
        {
            Day = reader.ReadByte();
            Month = reader.ReadByte();
            Year = reader.ReadShort();
        }

    }
}
