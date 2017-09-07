﻿namespace Messa.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    using Utils.IO;

    public class MoodSmileyUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6388;
        public override ushort MessageID => ProtocolId;
        public int AccountId { get; set; }
        public ulong PlayerId { get; set; }
        public ushort SmileyId { get; set; }

        public MoodSmileyUpdateMessage(int accountId, ulong playerId, ushort smileyId)
        {
            AccountId = accountId;
            PlayerId = playerId;
            SmileyId = smileyId;
        }

        public MoodSmileyUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadVarUhLong();
            SmileyId = reader.ReadVarUhShort();
        }

    }
}
