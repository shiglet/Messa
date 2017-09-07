﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class RecycleResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6601;
        public override ushort MessageID => ProtocolId;
        public uint NuggetsForPrism { get; set; }
        public uint NuggetsForPlayer { get; set; }

        public RecycleResultMessage(uint nuggetsForPrism, uint nuggetsForPlayer)
        {
            NuggetsForPrism = nuggetsForPrism;
            NuggetsForPlayer = nuggetsForPlayer;
        }

        public RecycleResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(NuggetsForPrism);
            writer.WriteVarUhInt(NuggetsForPlayer);
        }

        public override void Deserialize(IDataReader reader)
        {
            NuggetsForPrism = reader.ReadVarUhInt();
            NuggetsForPlayer = reader.ReadVarUhInt();
        }

    }
}
