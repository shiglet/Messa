﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Mount;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
    {
        public new const ushort ProtocolId = 5979;
        public override ushort MessageID => ProtocolId;
        public List<MountClientData> PaddockedMountsDescription { get; set; }

        public ExchangeStartOkMountMessage(List<MountClientData> paddockedMountsDescription)
        {
            PaddockedMountsDescription = paddockedMountsDescription;
        }

        public ExchangeStartOkMountMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)PaddockedMountsDescription.Count);
            for (var paddockedMountsDescriptionIndex = 0; paddockedMountsDescriptionIndex < PaddockedMountsDescription.Count; paddockedMountsDescriptionIndex++)
            {
                var objectToSend = PaddockedMountsDescription[paddockedMountsDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var paddockedMountsDescriptionCount = reader.ReadUShort();
            PaddockedMountsDescription = new List<MountClientData>();
            for (var paddockedMountsDescriptionIndex = 0; paddockedMountsDescriptionIndex < paddockedMountsDescriptionCount; paddockedMountsDescriptionIndex++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                PaddockedMountsDescription.Add(objectToAdd);
            }
        }

    }
}
