﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using System.Collections.Generic;
    using Utils.IO;

    public class RefreshFollowedQuestsOrderRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6722;
        public override ushort MessageID => ProtocolId;
        public List<ushort> Quests { get; set; }

        public RefreshFollowedQuestsOrderRequestMessage(List<ushort> quests)
        {
            Quests = quests;
        }

        public RefreshFollowedQuestsOrderRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Quests.Count);
            for (var questsIndex = 0; questsIndex < Quests.Count; questsIndex++)
            {
                writer.WriteVarUhShort(Quests[questsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var questsCount = reader.ReadUShort();
            Quests = new List<ushort>();
            for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
            {
                Quests.Add(reader.ReadVarUhShort());
            }
        }

    }
}
