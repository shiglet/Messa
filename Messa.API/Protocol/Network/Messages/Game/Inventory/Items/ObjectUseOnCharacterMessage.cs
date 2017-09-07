﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObjectUseOnCharacterMessage : ObjectUseMessage
    {
        public new const ushort ProtocolId = 3003;
        public override ushort MessageID => ProtocolId;
        public ulong CharacterId { get; set; }

        public ObjectUseOnCharacterMessage(ulong characterId)
        {
            CharacterId = characterId;
        }

        public ObjectUseOnCharacterMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CharacterId = reader.ReadVarUhLong();
        }

    }
}
