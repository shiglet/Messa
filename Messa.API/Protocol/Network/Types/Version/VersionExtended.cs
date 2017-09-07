﻿namespace Messa.API.Protocol.Network.Types.Version
{
    using Utils.IO;

    public class VersionExtended : Version
    {
        public new const ushort ProtocolId = 393;
        public override ushort TypeID => ProtocolId;
        public byte Install { get; set; }
        public byte Technology { get; set; }

        public VersionExtended(byte install, byte technology)
        {
            Install = install;
            Technology = technology;
        }

        public VersionExtended() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Install);
            writer.WriteByte(Technology);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Install = reader.ReadByte();
            Technology = reader.ReadByte();
        }

    }
}
