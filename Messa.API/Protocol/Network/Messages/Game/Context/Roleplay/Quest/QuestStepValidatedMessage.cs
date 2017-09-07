﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestStepValidatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6099;
        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }
        public ushort StepId { get; set; }

        public QuestStepValidatedMessage(ushort questId, ushort stepId)
        {
            QuestId = questId;
            StepId = stepId;
        }

        public QuestStepValidatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
            writer.WriteVarUhShort(StepId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
            StepId = reader.ReadVarUhShort();
        }

    }
}
