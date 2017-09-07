﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyMemberArenaInformations : PartyMemberInformations
    {
        public new const ushort ProtocolId = 391;
        public override ushort TypeID => ProtocolId;
        public ushort Rank { get; set; }

        public PartyMemberArenaInformations(ushort rank)
        {
            Rank = rank;
        }

        public PartyMemberArenaInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Rank);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarUhShort();
        }

    }
}
