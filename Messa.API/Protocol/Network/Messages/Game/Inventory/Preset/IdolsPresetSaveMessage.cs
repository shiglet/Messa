﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Messages.Game.Inventory;
    using Utils.IO;

    public class IdolsPresetSaveMessage : AbstractPresetSaveMessage
    {
        public new const ushort ProtocolId = 6603;
        public override ushort MessageID => ProtocolId;

        public IdolsPresetSaveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
