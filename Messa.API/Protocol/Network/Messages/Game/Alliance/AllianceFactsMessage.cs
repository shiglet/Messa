﻿namespace Messa.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Social;
    using System.Collections.Generic;
    using Utils.IO;

    public class AllianceFactsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6414;
        public override ushort MessageID => ProtocolId;
        public AllianceFactSheetInformations Infos { get; set; }
        public List<GuildInAllianceInformations> Guilds { get; set; }
        public List<ushort> ControlledSubareaIds { get; set; }
        public ulong LeaderCharacterId { get; set; }
        public string LeaderCharacterName { get; set; }

        public AllianceFactsMessage(AllianceFactSheetInformations infos, List<GuildInAllianceInformations> guilds, List<ushort> controlledSubareaIds, ulong leaderCharacterId, string leaderCharacterName)
        {
            Infos = infos;
            Guilds = guilds;
            ControlledSubareaIds = controlledSubareaIds;
            LeaderCharacterId = leaderCharacterId;
            LeaderCharacterName = leaderCharacterName;
        }

        public AllianceFactsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Infos.TypeID);
            Infos.Serialize(writer);
            writer.WriteShort((short)Guilds.Count);
            for (var guildsIndex = 0; guildsIndex < Guilds.Count; guildsIndex++)
            {
                var objectToSend = Guilds[guildsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short)ControlledSubareaIds.Count);
            for (var controlledSubareaIdsIndex = 0; controlledSubareaIdsIndex < ControlledSubareaIds.Count; controlledSubareaIdsIndex++)
            {
                writer.WriteVarUhShort(ControlledSubareaIds[controlledSubareaIdsIndex]);
            }
            writer.WriteVarUhLong(LeaderCharacterId);
            writer.WriteUTF(LeaderCharacterName);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance<AllianceFactSheetInformations>(reader.ReadUShort());
            Infos.Deserialize(reader);
            var guildsCount = reader.ReadUShort();
            Guilds = new List<GuildInAllianceInformations>();
            for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
            {
                var objectToAdd = new GuildInAllianceInformations();
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
            var controlledSubareaIdsCount = reader.ReadUShort();
            ControlledSubareaIds = new List<ushort>();
            for (var controlledSubareaIdsIndex = 0; controlledSubareaIdsIndex < controlledSubareaIdsCount; controlledSubareaIdsIndex++)
            {
                ControlledSubareaIds.Add(reader.ReadVarUhShort());
            }
            LeaderCharacterId = reader.ReadVarUhLong();
            LeaderCharacterName = reader.ReadUTF();
        }

    }
}
