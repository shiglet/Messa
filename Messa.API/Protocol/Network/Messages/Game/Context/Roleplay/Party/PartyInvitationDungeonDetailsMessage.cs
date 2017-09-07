﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using System.Collections.Generic;
    using Utils.IO;

    public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
    {
        public new const ushort ProtocolId = 6262;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public List<bool> PlayersDungeonReady { get; set; }

        public PartyInvitationDungeonDetailsMessage(ushort dungeonId, List<bool> playersDungeonReady)
        {
            DungeonId = dungeonId;
            PlayersDungeonReady = playersDungeonReady;
        }

        public PartyInvitationDungeonDetailsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(DungeonId);
            writer.WriteShort((short)PlayersDungeonReady.Count);
            for (var playersDungeonReadyIndex = 0; playersDungeonReadyIndex < PlayersDungeonReady.Count; playersDungeonReadyIndex++)
            {
                writer.WriteBoolean(PlayersDungeonReady[playersDungeonReadyIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarUhShort();
            var playersDungeonReadyCount = reader.ReadUShort();
            PlayersDungeonReady = new List<bool>();
            for (var playersDungeonReadyIndex = 0; playersDungeonReadyIndex < playersDungeonReadyCount; playersDungeonReadyIndex++)
            {
                PlayersDungeonReady.Add(reader.ReadBoolean());
            }
        }

    }
}
