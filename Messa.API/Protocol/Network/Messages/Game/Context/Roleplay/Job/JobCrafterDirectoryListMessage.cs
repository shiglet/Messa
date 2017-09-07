﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Types.Game.Context.Roleplay.Job;
    using System.Collections.Generic;
    using Utils.IO;

    public class JobCrafterDirectoryListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6046;
        public override ushort MessageID => ProtocolId;
        public List<JobCrafterDirectoryListEntry> ListEntries { get; set; }

        public JobCrafterDirectoryListMessage(List<JobCrafterDirectoryListEntry> listEntries)
        {
            ListEntries = listEntries;
        }

        public JobCrafterDirectoryListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ListEntries.Count);
            for (var listEntriesIndex = 0; listEntriesIndex < ListEntries.Count; listEntriesIndex++)
            {
                var objectToSend = ListEntries[listEntriesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var listEntriesCount = reader.ReadUShort();
            ListEntries = new List<JobCrafterDirectoryListEntry>();
            for (var listEntriesIndex = 0; listEntriesIndex < listEntriesCount; listEntriesIndex++)
            {
                var objectToAdd = new JobCrafterDirectoryListEntry();
                objectToAdd.Deserialize(reader);
                ListEntries.Add(objectToAdd);
            }
        }

    }
}
