﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangePlayerRequestMessage : ExchangeRequestMessage
    {
        public new const ushort ProtocolId = 5773;
        public override ushort MessageID => ProtocolId;
        public ulong Target { get; set; }

        public ExchangePlayerRequestMessage(ulong target)
        {
            Target = target;
        }

        public ExchangePlayerRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Target);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Target = reader.ReadVarUhLong();
        }

    }
}
