﻿namespace Messa.API.Protocol.Network.Messages.Game.Character.Deletion
{
    using Utils.IO;

    public class CharacterDeletionRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 165;
        public override ushort MessageID => ProtocolId;
        public ulong CharacterId { get; set; }
        public string SecretAnswerHash { get; set; }

        public CharacterDeletionRequestMessage(ulong characterId, string secretAnswerHash)
        {
            CharacterId = characterId;
            SecretAnswerHash = secretAnswerHash;
        }

        public CharacterDeletionRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
            writer.WriteUTF(SecretAnswerHash);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
            SecretAnswerHash = reader.ReadUTF();
        }

    }
}
