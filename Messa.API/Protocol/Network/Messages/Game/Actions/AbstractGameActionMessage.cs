﻿namespace Messa.API.Protocol.Network.Messages.Game.Actions
{
    using Utils.IO;

    public class AbstractGameActionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1000;
        public override ushort MessageID => ProtocolId;
        public ushort ActionId { get; set; }
        public double SourceId { get; set; }

        public AbstractGameActionMessage(ushort actionId, double sourceId)
        {
            ActionId = actionId;
            SourceId = sourceId;
        }

        public AbstractGameActionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
            writer.WriteDouble(SourceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
            SourceId = reader.ReadDouble();
        }

    }
}
