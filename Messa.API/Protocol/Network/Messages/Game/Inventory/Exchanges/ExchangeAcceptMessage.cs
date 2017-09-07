﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeAcceptMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5508;
        public override ushort MessageID => ProtocolId;

        public ExchangeAcceptMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
