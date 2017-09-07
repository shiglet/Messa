﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class PaddockRemoveItemRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5958;
        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public PaddockRemoveItemRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public PaddockRemoveItemRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
        }

    }
}
