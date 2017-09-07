﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntDigRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6485;
        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }

        public TreasureHuntDigRequestMessage(byte questType)
        {
            QuestType = questType;
        }

        public TreasureHuntDigRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
        }

    }
}
