﻿namespace Messa.API.Protocol.Network.Types.Game.House
{
    using Utils.IO;

    public class HouseInformationsInside : HouseInformations
    {
        public new const ushort ProtocolId = 218;
        public override ushort TypeID => ProtocolId;
        public HouseInstanceInformations HouseInfos { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }

        public HouseInformationsInside(HouseInstanceInformations houseInfos, short worldX, short worldY)
        {
            HouseInfos = houseInfos;
            WorldX = worldX;
            WorldY = worldY;
        }

        public HouseInformationsInside() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(HouseInfos.TypeID);
            HouseInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HouseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadUShort());
            HouseInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }

    }
}
