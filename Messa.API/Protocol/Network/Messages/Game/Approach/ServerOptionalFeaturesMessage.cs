﻿namespace Messa.API.Protocol.Network.Messages.Game.Approach
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ServerOptionalFeaturesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6305;
        public override ushort MessageID => ProtocolId;
        public List<byte> Features { get; set; }

        public ServerOptionalFeaturesMessage(List<byte> features)
        {
            Features = features;
        }

        public ServerOptionalFeaturesMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Features.Count);
            for (var featuresIndex = 0; featuresIndex < Features.Count; featuresIndex++)
            {
                writer.WriteByte(Features[featuresIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var featuresCount = reader.ReadUShort();
            Features = new List<byte>();
            for (var featuresIndex = 0; featuresIndex < featuresCount; featuresIndex++)
            {
                Features.Add(reader.ReadByte());
            }
        }

    }
}
