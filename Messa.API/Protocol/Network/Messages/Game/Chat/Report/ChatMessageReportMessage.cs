﻿namespace Messa.API.Protocol.Network.Messages.Game.Chat.Report
{
    using Utils.IO;

    public class ChatMessageReportMessage : NetworkMessage
    {
        public const ushort ProtocolId = 821;
        public override ushort MessageID => ProtocolId;
        public string SenderName { get; set; }
        public string Content { get; set; }
        public int Timestamp { get; set; }
        public byte Channel { get; set; }
        public string Fingerprint { get; set; }
        public byte Reason { get; set; }

        public ChatMessageReportMessage(string senderName, string content, int timestamp, byte channel, string fingerprint, byte reason)
        {
            SenderName = senderName;
            Content = content;
            Timestamp = timestamp;
            Channel = channel;
            Fingerprint = fingerprint;
            Reason = reason;
        }

        public ChatMessageReportMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(SenderName);
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteByte(Channel);
            writer.WriteUTF(Fingerprint);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            SenderName = reader.ReadUTF();
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            Channel = reader.ReadByte();
            Fingerprint = reader.ReadUTF();
            Reason = reader.ReadByte();
        }

    }
}
