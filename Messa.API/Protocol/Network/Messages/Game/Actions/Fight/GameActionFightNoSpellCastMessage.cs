﻿namespace Messa.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Utils.IO;

    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6132;
        public override ushort MessageID => ProtocolId;
        public uint SpellLevelId { get; set; }

        public GameActionFightNoSpellCastMessage(uint spellLevelId)
        {
            SpellLevelId = spellLevelId;
        }

        public GameActionFightNoSpellCastMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SpellLevelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellLevelId = reader.ReadVarUhInt();
        }

    }
}
