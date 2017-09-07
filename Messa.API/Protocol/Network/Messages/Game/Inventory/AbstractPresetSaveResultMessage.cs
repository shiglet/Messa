﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory
{
    using Utils.IO;

    public class AbstractPresetSaveResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6734;
        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte Code { get; set; }

        public AbstractPresetSaveResultMessage(byte presetId, byte code)
        {
            PresetId = presetId;
            Code = code;
        }

        public AbstractPresetSaveResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Code = reader.ReadByte();
        }

    }
}
