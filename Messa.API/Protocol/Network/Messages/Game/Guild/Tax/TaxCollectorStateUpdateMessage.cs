﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class TaxCollectorStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6455;
        public override ushort MessageID => ProtocolId;
        public int UniqueId { get; set; }
        public sbyte State { get; set; }

        public TaxCollectorStateUpdateMessage(int uniqueId, sbyte state)
        {
            UniqueId = uniqueId;
            State = state;
        }

        public TaxCollectorStateUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(UniqueId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            UniqueId = reader.ReadInt();
            State = reader.ReadSByte();
        }

    }
}
