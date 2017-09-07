﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Storage
{
    using System.Collections.Generic;
    using Utils.IO;

    public class StorageObjectsRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6035;
        public override ushort MessageID => ProtocolId;
        public List<uint> ObjectUIDList { get; set; }

        public StorageObjectsRemoveMessage(List<uint> objectUIDList)
        {
            ObjectUIDList = objectUIDList;
        }

        public StorageObjectsRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ObjectUIDList.Count);
            for (var objectUIDListIndex = 0; objectUIDListIndex < ObjectUIDList.Count; objectUIDListIndex++)
            {
                writer.WriteVarUhInt(ObjectUIDList[objectUIDListIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectUIDListCount = reader.ReadUShort();
            ObjectUIDList = new List<uint>();
            for (var objectUIDListIndex = 0; objectUIDListIndex < objectUIDListCount; objectUIDListIndex++)
            {
                ObjectUIDList.Add(reader.ReadVarUhInt());
            }
        }

    }
}
