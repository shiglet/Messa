﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBuyOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5759;
        public override ushort MessageID => ProtocolId;

        public ExchangeBuyOkMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
