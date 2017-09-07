﻿namespace Messa.API.Protocol.Network.Types.Updater
{
    using Utils.IO;

    public class ContentPart : NetworkType
    {
        public const ushort ProtocolId = 350;
        public override ushort TypeID => ProtocolId;
        public string ObjectId { get; set; }
        public byte State { get; set; }

        public ContentPart(string objectId, byte state)
        {
            ObjectId = objectId;
            State = state;
        }

        public ContentPart() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(ObjectId);
            writer.WriteByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadUTF();
            State = reader.ReadByte();
        }

    }
}
