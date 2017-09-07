﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Spell
{
    using Utils.IO;

    public class SpellModifyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6655;
        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }

        public SpellModifyRequestMessage(ushort spellId, short spellLevel)
        {
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public SpellModifyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            SpellLevel = reader.ReadShort();
        }

    }
}
