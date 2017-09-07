﻿namespace Messa.API.Protocol.Network.Types.Game.Context
{
    using Utils.IO;

    public class ActorOrientation : NetworkType
    {
        public const ushort ProtocolId = 353;
        public override ushort TypeID => ProtocolId;
        public double ObjectId { get; set; }
        public byte Direction { get; set; }

        public ActorOrientation(double objectId, byte direction)
        {
            ObjectId = objectId;
            Direction = direction;
        }

        public ActorOrientation() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            writer.WriteByte(Direction);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            Direction = reader.ReadByte();
        }

    }
}
