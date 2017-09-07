﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeMountSterilizeFromPaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6056;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public string Sterilizator { get; set; }

        public ExchangeMountSterilizeFromPaddockMessage(string name, short worldX, short worldY, string sterilizator)
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Sterilizator = sterilizator;
        }

        public ExchangeMountSterilizeFromPaddockMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Sterilizator);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Sterilizator = reader.ReadUTF();
        }

    }
}
