﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseTypeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5803;
        public override ushort MessageID => ProtocolId;
        public uint Type { get; set; }

        public ExchangeBidHouseTypeMessage(uint type)
        {
            Type = type;
        }

        public ExchangeBidHouseTypeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadVarUhInt();
        }

    }
}
