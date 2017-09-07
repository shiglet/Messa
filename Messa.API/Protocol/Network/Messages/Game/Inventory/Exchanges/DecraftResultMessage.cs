﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Context.Roleplay.Job;
    using System.Collections.Generic;
    using Utils.IO;

    public class DecraftResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6569;
        public override ushort MessageID => ProtocolId;
        public List<DecraftedItemStackInfo> Results { get; set; }

        public DecraftResultMessage(List<DecraftedItemStackInfo> results)
        {
            Results = results;
        }

        public DecraftResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Results.Count);
            for (var resultsIndex = 0; resultsIndex < Results.Count; resultsIndex++)
            {
                var objectToSend = Results[resultsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var resultsCount = reader.ReadUShort();
            Results = new List<DecraftedItemStackInfo>();
            for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
            {
                var objectToAdd = new DecraftedItemStackInfo();
                objectToAdd.Deserialize(reader);
                Results.Add(objectToAdd);
            }
        }

    }
}
