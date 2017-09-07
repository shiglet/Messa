﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Types.Game.Context.Roleplay.Party;
    using Utils.IO;

    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5575;
        public override ushort MessageID => ProtocolId;
        public PartyMemberInformations MemberInformations { get; set; }

        public PartyUpdateMessage(PartyMemberInformations memberInformations)
        {
            MemberInformations = memberInformations;
        }

        public PartyUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(MemberInformations.TypeID);
            MemberInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberInformations = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadUShort());
            MemberInformations.Deserialize(reader);
        }

    }
}
