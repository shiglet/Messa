﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using Utils.IO;

    public class HouseBuyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5738;
        public override ushort MessageID => ProtocolId;
        public ulong ProposedPrice { get; set; }

        public HouseBuyRequestMessage(ulong proposedPrice)
        {
            ProposedPrice = proposedPrice;
        }

        public HouseBuyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ProposedPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            ProposedPrice = reader.ReadVarUhLong();
        }

    }
}
