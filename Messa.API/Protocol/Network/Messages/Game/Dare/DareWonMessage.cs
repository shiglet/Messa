﻿namespace Messa.API.Protocol.Network.Messages.Game.Dare
{
    using Utils.IO;

    public class DareWonMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6681;
        public override ushort MessageID => ProtocolId;
        public double DareId { get; set; }

        public DareWonMessage(double dareId)
        {
            DareId = dareId;
        }

        public DareWonMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
        }

    }
}
