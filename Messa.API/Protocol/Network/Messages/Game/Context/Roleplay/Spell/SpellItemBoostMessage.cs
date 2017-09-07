﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Spell
{
    using Utils.IO;

    public class SpellItemBoostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6011;
        public override ushort MessageID => ProtocolId;
        public uint StatId { get; set; }
        public ushort SpellId { get; set; }
        public short Value { get; set; }

        public SpellItemBoostMessage(uint statId, ushort spellId, short value)
        {
            StatId = statId;
            SpellId = spellId;
            Value = value;
        }

        public SpellItemBoostMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(StatId);
            writer.WriteVarUhShort(SpellId);
            writer.WriteVarShort(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatId = reader.ReadVarUhInt();
            SpellId = reader.ReadVarUhShort();
            Value = reader.ReadVarShort();
        }

    }
}
