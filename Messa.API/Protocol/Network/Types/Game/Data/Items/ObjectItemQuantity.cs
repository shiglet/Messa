﻿namespace Messa.API.Protocol.Network.Types.Game.Data.Items
{
    using Utils.IO;

    public class ObjectItemQuantity : Item
    {
        public new const ushort ProtocolId = 119;
        public override ushort TypeID => ProtocolId;
        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }

        public ObjectItemQuantity(uint objectUID, uint quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ObjectItemQuantity() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }

    }
}
