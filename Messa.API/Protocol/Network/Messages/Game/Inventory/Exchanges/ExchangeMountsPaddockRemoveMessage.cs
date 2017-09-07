﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeMountsPaddockRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6559;
        public override ushort MessageID => ProtocolId;
        public List<int> MountsId { get; set; }

        public ExchangeMountsPaddockRemoveMessage(List<int> mountsId)
        {
            MountsId = mountsId;
        }

        public ExchangeMountsPaddockRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)MountsId.Count);
            for (var mountsIdIndex = 0; mountsIdIndex < MountsId.Count; mountsIdIndex++)
            {
                writer.WriteVarInt(MountsId[mountsIdIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var mountsIdCount = reader.ReadUShort();
            MountsId = new List<int>();
            for (var mountsIdIndex = 0; mountsIdIndex < mountsIdCount; mountsIdIndex++)
            {
                MountsId.Add(reader.ReadVarInt());
            }
        }

    }
}
