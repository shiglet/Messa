﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeStartOkJobIndexMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5819;
        public override ushort MessageID => ProtocolId;
        public List<uint> Jobs { get; set; }

        public ExchangeStartOkJobIndexMessage(List<uint> jobs)
        {
            Jobs = jobs;
        }

        public ExchangeStartOkJobIndexMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Jobs.Count);
            for (var jobsIndex = 0; jobsIndex < Jobs.Count; jobsIndex++)
            {
                writer.WriteVarUhInt(Jobs[jobsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobsCount = reader.ReadUShort();
            Jobs = new List<uint>();
            for (var jobsIndex = 0; jobsIndex < jobsCount; jobsIndex++)
            {
                Jobs.Add(reader.ReadVarUhInt());
            }
        }

    }
}
