﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class HumanOptionAlliance : HumanOption
    {
        public new const ushort ProtocolId = 425;
        public override ushort TypeID => ProtocolId;
        public AllianceInformations AllianceInformations { get; set; }
        public byte Aggressable { get; set; }

        public HumanOptionAlliance(AllianceInformations allianceInformations, byte aggressable)
        {
            AllianceInformations = allianceInformations;
            Aggressable = aggressable;
        }

        public HumanOptionAlliance() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInformations.Serialize(writer);
            writer.WriteByte(Aggressable);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInformations = new AllianceInformations();
            AllianceInformations.Deserialize(reader);
            Aggressable = reader.ReadByte();
        }

    }
}
