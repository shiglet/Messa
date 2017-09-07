﻿namespace Messa.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Utils.IO;

    public class CharacterExperienceGainMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6321;
        public override ushort MessageID => ProtocolId;
        public ulong ExperienceCharacter { get; set; }
        public ulong ExperienceMount { get; set; }
        public ulong ExperienceGuild { get; set; }
        public ulong ExperienceIncarnation { get; set; }

        public CharacterExperienceGainMessage(ulong experienceCharacter, ulong experienceMount, ulong experienceGuild, ulong experienceIncarnation)
        {
            ExperienceCharacter = experienceCharacter;
            ExperienceMount = experienceMount;
            ExperienceGuild = experienceGuild;
            ExperienceIncarnation = experienceIncarnation;
        }

        public CharacterExperienceGainMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ExperienceCharacter);
            writer.WriteVarUhLong(ExperienceMount);
            writer.WriteVarUhLong(ExperienceGuild);
            writer.WriteVarUhLong(ExperienceIncarnation);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperienceCharacter = reader.ReadVarUhLong();
            ExperienceMount = reader.ReadVarUhLong();
            ExperienceGuild = reader.ReadVarUhLong();
            ExperienceIncarnation = reader.ReadVarUhLong();
        }

    }
}
