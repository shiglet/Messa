﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage
    {
        public new const ushort ProtocolId = 6557;
        public override ushort MessageID => ProtocolId;

        public ExchangeMountsStableBornAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
