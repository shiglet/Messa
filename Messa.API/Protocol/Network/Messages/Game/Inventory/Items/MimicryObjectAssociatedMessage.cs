﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class MimicryObjectAssociatedMessage : SymbioticObjectAssociatedMessage
    {
        public new const ushort ProtocolId = 6462;
        public override ushort MessageID => ProtocolId;

        public MimicryObjectAssociatedMessage() { }

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
