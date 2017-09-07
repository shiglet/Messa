﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeObjectTransfertListFromInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6183;
        public override ushort MessageID => ProtocolId;
        public List<uint> Ids { get; set; }

        public ExchangeObjectTransfertListFromInvMessage(List<uint> ids)
        {
            Ids = ids;
        }

        public ExchangeObjectTransfertListFromInvMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Ids.Count);
            for (var idsIndex = 0; idsIndex < Ids.Count; idsIndex++)
            {
                writer.WriteVarUhInt(Ids[idsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new List<uint>();
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
            {
                Ids.Add(reader.ReadVarUhInt());
            }
        }

    }
}
