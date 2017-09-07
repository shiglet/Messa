﻿namespace Messa.API.Protocol.Network.Messages.Game.Interactive
{
    using Types.Game.Interactive;
    using System.Collections.Generic;
    using Utils.IO;

    public class InteractiveMapUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5002;
        public override ushort MessageID => ProtocolId;
        public List<InteractiveElement> InteractiveElements { get; set; }

        public InteractiveMapUpdateMessage(List<InteractiveElement> interactiveElements)
        {
            InteractiveElements = interactiveElements;
        }

        public InteractiveMapUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)InteractiveElements.Count);
            for (var interactiveElementsIndex = 0; interactiveElementsIndex < InteractiveElements.Count; interactiveElementsIndex++)
            {
                var objectToSend = InteractiveElements[interactiveElementsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var interactiveElementsCount = reader.ReadUShort();
            InteractiveElements = new List<InteractiveElement>();
            for (var interactiveElementsIndex = 0; interactiveElementsIndex < interactiveElementsCount; interactiveElementsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                InteractiveElements.Add(objectToAdd);
            }
        }

    }
}
