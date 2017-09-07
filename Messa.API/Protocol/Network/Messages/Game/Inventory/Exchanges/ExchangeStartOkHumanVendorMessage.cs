﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeStartOkHumanVendorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5767;
        public override ushort MessageID => ProtocolId;
        public double SellerId { get; set; }
        public List<ObjectItemToSellInHumanVendorShop> ObjectsInfos { get; set; }

        public ExchangeStartOkHumanVendorMessage(double sellerId, List<ObjectItemToSellInHumanVendorShop> objectsInfos)
        {
            SellerId = sellerId;
            ObjectsInfos = objectsInfos;
        }

        public ExchangeStartOkHumanVendorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SellerId);
            writer.WriteShort((short)ObjectsInfos.Count);
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count; objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SellerId = reader.ReadDouble();
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new List<ObjectItemToSellInHumanVendorShop>();
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSellInHumanVendorShop();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }

    }
}
