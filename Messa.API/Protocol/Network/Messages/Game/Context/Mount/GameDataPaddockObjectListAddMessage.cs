﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Types.Game.Paddock;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameDataPaddockObjectListAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5992;
        public override ushort MessageID => ProtocolId;
        public List<PaddockItem> PaddockItemDescription { get; set; }

        public GameDataPaddockObjectListAddMessage(List<PaddockItem> paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public GameDataPaddockObjectListAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)PaddockItemDescription.Count);
            for (var paddockItemDescriptionIndex = 0; paddockItemDescriptionIndex < PaddockItemDescription.Count; paddockItemDescriptionIndex++)
            {
                var objectToSend = PaddockItemDescription[paddockItemDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var paddockItemDescriptionCount = reader.ReadUShort();
            PaddockItemDescription = new List<PaddockItem>();
            for (var paddockItemDescriptionIndex = 0; paddockItemDescriptionIndex < paddockItemDescriptionCount; paddockItemDescriptionIndex++)
            {
                var objectToAdd = new PaddockItem();
                objectToAdd.Deserialize(reader);
                PaddockItemDescription.Add(objectToAdd);
            }
        }

    }
}
