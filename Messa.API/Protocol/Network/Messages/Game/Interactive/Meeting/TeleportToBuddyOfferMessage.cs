﻿namespace Messa.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    using Utils.IO;

    public class TeleportToBuddyOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6287;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public ulong BuddyId { get; set; }
        public uint TimeLeft { get; set; }

        public TeleportToBuddyOfferMessage(ushort dungeonId, ulong buddyId, uint timeLeft)
        {
            DungeonId = dungeonId;
            BuddyId = buddyId;
            TimeLeft = timeLeft;
        }

        public TeleportToBuddyOfferMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(BuddyId);
            writer.WriteVarUhInt(TimeLeft);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            BuddyId = reader.ReadVarUhLong();
            TimeLeft = reader.ReadVarUhInt();
        }

    }
}
