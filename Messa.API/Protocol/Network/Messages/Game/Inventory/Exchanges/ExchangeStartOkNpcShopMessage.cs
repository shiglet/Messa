﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeStartOkNpcShopMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5761;
        public override ushort MessageID => ProtocolId;
        public double NpcSellerId { get; set; }
        public ushort TokenId { get; set; }
        public List<ObjectItemToSellInNpcShop> ObjectsInfos { get; set; }

        public ExchangeStartOkNpcShopMessage(double npcSellerId, ushort tokenId, List<ObjectItemToSellInNpcShop> objectsInfos)
        {
            NpcSellerId = npcSellerId;
            TokenId = tokenId;
            ObjectsInfos = objectsInfos;
        }

        public ExchangeStartOkNpcShopMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(NpcSellerId);
            writer.WriteVarUhShort(TokenId);
            writer.WriteShort((short)ObjectsInfos.Count);
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count; objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcSellerId = reader.ReadDouble();
            TokenId = reader.ReadVarUhShort();
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new List<ObjectItemToSellInNpcShop>();
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSellInNpcShop();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }

    }
}
