﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5512;
        public override ushort MessageID => ProtocolId;
        public sbyte ExchangeType { get; set; }

        public ExchangeStartedMessage(sbyte exchangeType)
        {
            ExchangeType = exchangeType;
        }

        public ExchangeStartedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ExchangeType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExchangeType = reader.ReadSByte();
        }

    }
}
