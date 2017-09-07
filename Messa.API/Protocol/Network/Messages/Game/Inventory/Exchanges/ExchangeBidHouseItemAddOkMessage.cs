﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5945;
        public override ushort MessageID => ProtocolId;
        public ObjectItemToSellInBid ItemInfo { get; set; }

        public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
        {
            ItemInfo = itemInfo;
        }

        public ExchangeBidHouseItemAddOkMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            ItemInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemInfo = new ObjectItemToSellInBid();
            ItemInfo.Deserialize(reader);
        }

    }
}
