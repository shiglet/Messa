﻿namespace Messa.API.Protocol.Network.Messages.Connection
{
    using System.Collections.Generic;
    using Utils.IO;

    public class HelloConnectMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3;
        public override ushort MessageID => ProtocolId;
        public string Salt { get; set; }
        public List<sbyte> Key { get; set; }

        public HelloConnectMessage(string salt, List<sbyte> key)
        {
            Salt = salt;
            Key = key;
        }

        public HelloConnectMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteVarInt(Key.Count);
            for (var keyIndex = 0; keyIndex < Key.Count; keyIndex++)
            {
                writer.WriteSByte(Key[keyIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Salt = reader.ReadUTF();
            var keyCount = reader.ReadVarInt();
            Key = new List<sbyte>();
            for (var keyIndex = 0; keyIndex < keyCount; keyIndex++)
            {
                Key.Add(reader.ReadSByte());
            }
        }

    }
}
