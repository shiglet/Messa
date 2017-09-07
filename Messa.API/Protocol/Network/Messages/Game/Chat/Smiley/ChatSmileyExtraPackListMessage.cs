﻿namespace Messa.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ChatSmileyExtraPackListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6596;
        public override ushort MessageID => ProtocolId;
        public List<byte> PackIds { get; set; }

        public ChatSmileyExtraPackListMessage(List<byte> packIds)
        {
            PackIds = packIds;
        }

        public ChatSmileyExtraPackListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)PackIds.Count);
            for (var packIdsIndex = 0; packIdsIndex < PackIds.Count; packIdsIndex++)
            {
                writer.WriteByte(PackIds[packIdsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var packIdsCount = reader.ReadUShort();
            PackIds = new List<byte>();
            for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++)
            {
                PackIds.Add(reader.ReadByte());
            }
        }

    }
}
