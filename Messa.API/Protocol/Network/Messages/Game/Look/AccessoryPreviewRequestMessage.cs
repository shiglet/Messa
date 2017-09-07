﻿namespace Messa.API.Protocol.Network.Messages.Game.Look
{
    using System.Collections.Generic;
    using Utils.IO;

    public class AccessoryPreviewRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6518;
        public override ushort MessageID => ProtocolId;
        public List<ushort> GenericId { get; set; }

        public AccessoryPreviewRequestMessage(List<ushort> genericId)
        {
            GenericId = genericId;
        }

        public AccessoryPreviewRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)GenericId.Count);
            for (var genericIdIndex = 0; genericIdIndex < GenericId.Count; genericIdIndex++)
            {
                writer.WriteVarUhShort(GenericId[genericIdIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var genericIdCount = reader.ReadUShort();
            GenericId = new List<ushort>();
            for (var genericIdIndex = 0; genericIdIndex < genericIdCount; genericIdIndex++)
            {
                GenericId.Add(reader.ReadVarUhShort());
            }
        }

    }
}
