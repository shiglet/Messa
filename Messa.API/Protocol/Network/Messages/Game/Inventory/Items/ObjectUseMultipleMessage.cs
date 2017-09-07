﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObjectUseMultipleMessage : ObjectUseMessage
    {
        public new const ushort ProtocolId = 6234;
        public override ushort MessageID => ProtocolId;
        public uint Quantity { get; set; }

        public ObjectUseMultipleMessage(uint quantity)
        {
            Quantity = quantity;
        }

        public ObjectUseMultipleMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarUhInt();
        }

    }
}
