﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6091;
        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }

        public QuestStartedMessage(ushort questId)
        {
            QuestId = questId;
        }

        public QuestStartedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
        }

    }
}
