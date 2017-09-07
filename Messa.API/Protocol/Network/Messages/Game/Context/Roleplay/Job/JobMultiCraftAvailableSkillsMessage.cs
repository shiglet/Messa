﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using System.Collections.Generic;
    using Utils.IO;

    public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
    {
        public new const ushort ProtocolId = 5747;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }
        public List<ushort> Skills { get; set; }

        public JobMultiCraftAvailableSkillsMessage(ulong playerId, List<ushort> skills)
        {
            PlayerId = playerId;
            Skills = skills;
        }

        public JobMultiCraftAvailableSkillsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteShort((short)Skills.Count);
            for (var skillsIndex = 0; skillsIndex < Skills.Count; skillsIndex++)
            {
                writer.WriteVarUhShort(Skills[skillsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            var skillsCount = reader.ReadUShort();
            Skills = new List<ushort>();
            for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++)
            {
                Skills.Add(reader.ReadVarUhShort());
            }
        }

    }
}
