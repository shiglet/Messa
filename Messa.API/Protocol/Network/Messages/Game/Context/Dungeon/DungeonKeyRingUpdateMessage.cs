﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Dungeon
{
    using Utils.IO;

    public class DungeonKeyRingUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6296;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public bool Available { get; set; }

        public DungeonKeyRingUpdateMessage(ushort dungeonId, bool available)
        {
            DungeonId = dungeonId;
            Available = available;
        }

        public DungeonKeyRingUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteBoolean(Available);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            Available = reader.ReadBoolean();
        }

    }
}
