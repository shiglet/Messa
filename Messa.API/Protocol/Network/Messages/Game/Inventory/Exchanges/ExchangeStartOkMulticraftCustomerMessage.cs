﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartOkMulticraftCustomerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5817;
        public override ushort MessageID => ProtocolId;
        public uint SkillId { get; set; }
        public byte CrafterJobLevel { get; set; }

        public ExchangeStartOkMulticraftCustomerMessage(uint skillId, byte crafterJobLevel)
        {
            SkillId = skillId;
            CrafterJobLevel = crafterJobLevel;
        }

        public ExchangeStartOkMulticraftCustomerMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SkillId);
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUhInt();
            CrafterJobLevel = reader.ReadByte();
        }

    }
}
