﻿namespace Messa.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    using Utils.IO;

    public class TeleportToBuddyAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6293;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public ulong BuddyId { get; set; }
        public bool Accept { get; set; }

        public TeleportToBuddyAnswerMessage(ushort dungeonId, ulong buddyId, bool accept)
        {
            DungeonId = dungeonId;
            BuddyId = buddyId;
            Accept = accept;
        }

        public TeleportToBuddyAnswerMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(BuddyId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            BuddyId = reader.ReadVarUhLong();
            Accept = reader.ReadBoolean();
        }

    }
}
