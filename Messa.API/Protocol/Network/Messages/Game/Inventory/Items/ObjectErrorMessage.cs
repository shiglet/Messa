﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObjectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3004;
        public override ushort MessageID => ProtocolId;
        public sbyte Reason { get; set; }

        public ObjectErrorMessage(sbyte reason)
        {
            Reason = reason;
        }

        public ObjectErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }

    }
}
