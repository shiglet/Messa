﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    using Utils.IO;

    public class EmoteRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5687;
        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }

        public EmoteRemoveMessage(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public EmoteRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(IDataReader reader)
        {
            EmoteId = reader.ReadByte();
        }

    }
}
