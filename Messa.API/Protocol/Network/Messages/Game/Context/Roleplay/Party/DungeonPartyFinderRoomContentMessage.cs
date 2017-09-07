﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Types.Game.Context.Roleplay.Party;
    using System.Collections.Generic;
    using Utils.IO;

    public class DungeonPartyFinderRoomContentMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6247;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public List<DungeonPartyFinderPlayer> Players { get; set; }

        public DungeonPartyFinderRoomContentMessage(ushort dungeonId, List<DungeonPartyFinderPlayer> players)
        {
            DungeonId = dungeonId;
            Players = players;
        }

        public DungeonPartyFinderRoomContentMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteShort((short)Players.Count);
            for (var playersIndex = 0; playersIndex < Players.Count; playersIndex++)
            {
                var objectToSend = Players[playersIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            var playersCount = reader.ReadUShort();
            Players = new List<DungeonPartyFinderPlayer>();
            for (var playersIndex = 0; playersIndex < playersCount; playersIndex++)
            {
                var objectToAdd = new DungeonPartyFinderPlayer();
                objectToAdd.Deserialize(reader);
                Players.Add(objectToAdd);
            }
        }

    }
}
