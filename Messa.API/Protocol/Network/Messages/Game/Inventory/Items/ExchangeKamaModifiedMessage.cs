﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Messages.Game.Inventory.Exchanges;
    using Utils.IO;

    public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 5521;
        public override ushort MessageID => ProtocolId;
        public ulong Quantity { get; set; }

        public ExchangeKamaModifiedMessage(ulong quantity)
        {
            Quantity = quantity;
        }

        public ExchangeKamaModifiedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarUhLong();
        }

    }
}
