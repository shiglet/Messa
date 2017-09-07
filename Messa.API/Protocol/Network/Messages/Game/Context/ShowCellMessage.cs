﻿namespace Messa.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class ShowCellMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5612;
        public override ushort MessageID => ProtocolId;
        public double SourceId { get; set; }
        public ushort CellId { get; set; }

        public ShowCellMessage(double sourceId, ushort cellId)
        {
            SourceId = sourceId;
            CellId = cellId;
        }

        public ShowCellMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SourceId);
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SourceId = reader.ReadDouble();
            CellId = reader.ReadVarUhShort();
        }

    }
}
