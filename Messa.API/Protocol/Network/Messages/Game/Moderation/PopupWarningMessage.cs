﻿namespace Messa.API.Protocol.Network.Messages.Game.Moderation
{
    using Utils.IO;

    public class PopupWarningMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6134;
        public override ushort MessageID => ProtocolId;
        public byte LockDuration { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        public PopupWarningMessage(byte lockDuration, string author, string content)
        {
            LockDuration = lockDuration;
            Author = author;
            Content = content;
        }

        public PopupWarningMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(LockDuration);
            writer.WriteUTF(Author);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            LockDuration = reader.ReadByte();
            Author = reader.ReadUTF();
            Content = reader.ReadUTF();
        }

    }
}
