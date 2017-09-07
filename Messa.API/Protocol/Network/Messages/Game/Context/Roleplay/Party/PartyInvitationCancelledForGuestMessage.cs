﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6256;
        public override ushort MessageID => ProtocolId;
        public ulong CancelerId { get; set; }

        public PartyInvitationCancelledForGuestMessage(ulong cancelerId)
        {
            CancelerId = cancelerId;
        }

        public PartyInvitationCancelledForGuestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CancelerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarUhLong();
        }

    }
}
