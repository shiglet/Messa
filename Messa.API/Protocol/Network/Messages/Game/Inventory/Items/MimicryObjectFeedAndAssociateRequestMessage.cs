﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
    {
        public new const ushort ProtocolId = 6460;
        public override ushort MessageID => ProtocolId;
        public uint FoodUID { get; set; }
        public byte FoodPos { get; set; }
        public bool Preview { get; set; }

        public MimicryObjectFeedAndAssociateRequestMessage(uint foodUID, byte foodPos, bool preview)
        {
            FoodUID = foodUID;
            FoodPos = foodPos;
            Preview = preview;
        }

        public MimicryObjectFeedAndAssociateRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(FoodUID);
            writer.WriteByte(FoodPos);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FoodUID = reader.ReadVarUhInt();
            FoodPos = reader.ReadByte();
            Preview = reader.ReadBoolean();
        }

    }
}
