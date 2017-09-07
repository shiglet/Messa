﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseBuyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5804;
        public override ushort MessageID => ProtocolId;
        public uint Uid { get; set; }
        public uint Qty { get; set; }
        public ulong Price { get; set; }

        public ExchangeBidHouseBuyMessage(uint uid, uint qty, ulong price)
        {
            Uid = uid;
            Qty = qty;
            Price = price;
        }

        public ExchangeBidHouseBuyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteVarUhInt(Qty);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            Qty = reader.ReadVarUhInt();
            Price = reader.ReadVarUhLong();
        }

    }
}
