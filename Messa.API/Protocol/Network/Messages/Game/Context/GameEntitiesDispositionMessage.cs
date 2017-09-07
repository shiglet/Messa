﻿namespace Messa.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Context;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameEntitiesDispositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5696;
        public override ushort MessageID => ProtocolId;
        public List<IdentifiedEntityDispositionInformations> Dispositions { get; set; }

        public GameEntitiesDispositionMessage(List<IdentifiedEntityDispositionInformations> dispositions)
        {
            Dispositions = dispositions;
        }

        public GameEntitiesDispositionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Dispositions.Count);
            for (var dispositionsIndex = 0; dispositionsIndex < Dispositions.Count; dispositionsIndex++)
            {
                var objectToSend = Dispositions[dispositionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var dispositionsCount = reader.ReadUShort();
            Dispositions = new List<IdentifiedEntityDispositionInformations>();
            for (var dispositionsIndex = 0; dispositionsIndex < dispositionsCount; dispositionsIndex++)
            {
                var objectToAdd = new IdentifiedEntityDispositionInformations();
                objectToAdd.Deserialize(reader);
                Dispositions.Add(objectToAdd);
            }
        }

    }
}
