﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using Utils.IO;

    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public new const ushort ProtocolId = 33;
        public override ushort TypeID => ProtocolId;
        public List<FightTeamMemberInformations> TeamMembers { get; set; }

        public FightTeamInformations(List<FightTeamMemberInformations> teamMembers)
        {
            TeamMembers = teamMembers;
        }

        public FightTeamInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)TeamMembers.Count);
            for (var teamMembersIndex = 0; teamMembersIndex < TeamMembers.Count; teamMembersIndex++)
            {
                var objectToSend = TeamMembers[teamMembersIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var teamMembersCount = reader.ReadUShort();
            TeamMembers = new List<FightTeamMemberInformations>();
            for (var teamMembersIndex = 0; teamMembersIndex < teamMembersCount; teamMembersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                TeamMembers.Add(objectToAdd);
            }
        }

    }
}
