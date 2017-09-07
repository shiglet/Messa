﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class PortalInformation : NetworkType
    {
        public const ushort ProtocolId = 466;
        public override ushort TypeID => ProtocolId;
        public int PortalId { get; set; }
        public short AreaId { get; set; }

        public PortalInformation(int portalId, short areaId)
        {
            PortalId = portalId;
            AreaId = areaId;
        }

        public PortalInformation() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PortalId);
            writer.WriteShort(AreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PortalId = reader.ReadInt();
            AreaId = reader.ReadShort();
        }

    }
}
