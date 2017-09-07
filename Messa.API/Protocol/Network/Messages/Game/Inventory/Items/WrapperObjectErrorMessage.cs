﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const ushort ProtocolId = 6529;
        public override ushort MessageID => ProtocolId;

        public WrapperObjectErrorMessage() { }

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
