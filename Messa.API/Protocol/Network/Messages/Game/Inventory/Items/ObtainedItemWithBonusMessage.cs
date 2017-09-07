﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObtainedItemWithBonusMessage : ObtainedItemMessage
    {
        public new const ushort ProtocolId = 6520;
        public override ushort MessageID => ProtocolId;
        public uint BonusQuantity { get; set; }

        public ObtainedItemWithBonusMessage(uint bonusQuantity)
        {
            BonusQuantity = bonusQuantity;
        }

        public ObtainedItemWithBonusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(BonusQuantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BonusQuantity = reader.ReadVarUhInt();
        }

    }
}
