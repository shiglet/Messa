﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 6251;
        public override ushort MessageID => ProtocolId;
        public ulong CancelerId { get; set; }
        public ulong GuestId { get; set; }

        public PartyCancelInvitationNotificationMessage(ulong cancelerId, ulong guestId)
        {
            CancelerId = cancelerId;
            GuestId = guestId;
        }

        public PartyCancelInvitationNotificationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CancelerId);
            writer.WriteVarUhLong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarUhLong();
            GuestId = reader.ReadVarUhLong();
        }

    }
}
