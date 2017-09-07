﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GameRolePlayTaxCollectorFightRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5954;
        public override ushort MessageID => ProtocolId;
        public int TaxCollectorId { get; set; }

        public GameRolePlayTaxCollectorFightRequestMessage(int taxCollectorId)
        {
            TaxCollectorId = taxCollectorId;
        }

        public GameRolePlayTaxCollectorFightRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(TaxCollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadInt();
        }

    }
}
