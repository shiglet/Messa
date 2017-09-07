﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using Utils.IO;

    public class ExchangeObjectAddedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 5516;
        public override ushort MessageID => ProtocolId;
        public ObjectItem Object { get; set; }

        public ExchangeObjectAddedMessage(ObjectItem @object)
        {
            Object = @object;
        }

        public ExchangeObjectAddedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Object = new ObjectItem();
            Object.Deserialize(reader);
        }

    }
}
