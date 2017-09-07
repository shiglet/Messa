﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5772;
        public override ushort MessageID => ProtocolId;
        public ulong HumanVendorId { get; set; }
        public ushort HumanVendorCell { get; set; }

        public ExchangeOnHumanVendorRequestMessage(ulong humanVendorId, ushort humanVendorCell)
        {
            HumanVendorId = humanVendorId;
            HumanVendorCell = humanVendorCell;
        }

        public ExchangeOnHumanVendorRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(HumanVendorId);
            writer.WriteVarUhShort(HumanVendorCell);
        }

        public override void Deserialize(IDataReader reader)
        {
            HumanVendorId = reader.ReadVarUhLong();
            HumanVendorCell = reader.ReadVarUhShort();
        }

    }
}
