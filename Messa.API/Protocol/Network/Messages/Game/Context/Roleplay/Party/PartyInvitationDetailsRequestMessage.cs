﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyInvitationDetailsRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6264;
        public override ushort MessageID => ProtocolId;

        public PartyInvitationDetailsRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
