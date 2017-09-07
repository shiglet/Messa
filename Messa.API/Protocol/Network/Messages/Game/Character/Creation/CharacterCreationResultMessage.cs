﻿namespace Messa.API.Protocol.Network.Messages.Game.Character.Creation
{
    using Utils.IO;

    public class CharacterCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 161;
        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

        public CharacterCreationResultMessage(byte result)
        {
            Result = result;
        }

        public CharacterCreationResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadByte();
        }

    }
}
