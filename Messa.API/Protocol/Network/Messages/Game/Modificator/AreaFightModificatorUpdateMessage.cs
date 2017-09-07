﻿namespace Messa.API.Protocol.Network.Messages.Game.Modificator
{
    using Utils.IO;

    public class AreaFightModificatorUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6493;
        public override ushort MessageID => ProtocolId;
        public int SpellPairId { get; set; }

        public AreaFightModificatorUpdateMessage(int spellPairId)
        {
            SpellPairId = spellPairId;
        }

        public AreaFightModificatorUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellPairId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellPairId = reader.ReadInt();
        }

    }
}
