﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6037;
        public override ushort MessageID => ProtocolId;
        public List<uint> ObjectIdList { get; set; }

        public ExchangeShopStockMultiMovementRemovedMessage(List<uint> objectIdList)
        {
            ObjectIdList = objectIdList;
        }

        public ExchangeShopStockMultiMovementRemovedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ObjectIdList.Count);
            for (var objectIdListIndex = 0; objectIdListIndex < ObjectIdList.Count; objectIdListIndex++)
            {
                writer.WriteVarUhInt(ObjectIdList[objectIdListIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectIdListCount = reader.ReadUShort();
            ObjectIdList = new List<uint>();
            for (var objectIdListIndex = 0; objectIdListIndex < objectIdListCount; objectIdListIndex++)
            {
                ObjectIdList.Add(reader.ReadVarUhInt());
            }
        }

    }
}
