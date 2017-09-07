﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory
{
    using Utils.IO;

    public class AbstractPresetSaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6736;
        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte SymbolId { get; set; }

        public AbstractPresetSaveMessage(byte presetId, byte symbolId)
        {
            PresetId = presetId;
            SymbolId = symbolId;
        }

        public AbstractPresetSaveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(SymbolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            SymbolId = reader.ReadByte();
        }

    }
}
