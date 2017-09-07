﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Types.Game.Character.Characteristic;
    using Types.Game.Data.Items;
    using Types.Game.Shortcut;
    using System.Collections.Generic;
    using Utils.IO;

    public class SlaveSwitchContextMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6214;
        public override ushort MessageID => ProtocolId;
        public double MasterId { get; set; }
        public double SlaveId { get; set; }
        public List<SpellItem> SlaveSpells { get; set; }
        public CharacterCharacteristicsInformations SlaveStats { get; set; }
        public List<Shortcut> Shortcuts { get; set; }

        public SlaveSwitchContextMessage(double masterId, double slaveId, List<SpellItem> slaveSpells, CharacterCharacteristicsInformations slaveStats, List<Shortcut> shortcuts)
        {
            MasterId = masterId;
            SlaveId = slaveId;
            SlaveSpells = slaveSpells;
            SlaveStats = slaveStats;
            Shortcuts = shortcuts;
        }

        public SlaveSwitchContextMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MasterId);
            writer.WriteDouble(SlaveId);
            writer.WriteShort((short)SlaveSpells.Count);
            for (var slaveSpellsIndex = 0; slaveSpellsIndex < SlaveSpells.Count; slaveSpellsIndex++)
            {
                var objectToSend = SlaveSpells[slaveSpellsIndex];
                objectToSend.Serialize(writer);
            }
            SlaveStats.Serialize(writer);
            writer.WriteShort((short)Shortcuts.Count);
            for (var shortcutsIndex = 0; shortcutsIndex < Shortcuts.Count; shortcutsIndex++)
            {
                var objectToSend = Shortcuts[shortcutsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            MasterId = reader.ReadDouble();
            SlaveId = reader.ReadDouble();
            var slaveSpellsCount = reader.ReadUShort();
            SlaveSpells = new List<SpellItem>();
            for (var slaveSpellsIndex = 0; slaveSpellsIndex < slaveSpellsCount; slaveSpellsIndex++)
            {
                var objectToAdd = new SpellItem();
                objectToAdd.Deserialize(reader);
                SlaveSpells.Add(objectToAdd);
            }
            SlaveStats = new CharacterCharacteristicsInformations();
            SlaveStats.Deserialize(reader);
            var shortcutsCount = reader.ReadUShort();
            Shortcuts = new List<Shortcut>();
            for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Shortcuts.Add(objectToAdd);
            }
        }

    }
}
