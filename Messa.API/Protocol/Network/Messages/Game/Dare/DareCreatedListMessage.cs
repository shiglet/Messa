﻿namespace Messa.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using System.Collections.Generic;
    using Utils.IO;

    public class DareCreatedListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6663;
        public override ushort MessageID => ProtocolId;
        public List<DareInformations> DaresFixedInfos { get; set; }
        public List<DareVersatileInformations> DaresVersatilesInfos { get; set; }

        public DareCreatedListMessage(List<DareInformations> daresFixedInfos, List<DareVersatileInformations> daresVersatilesInfos)
        {
            DaresFixedInfos = daresFixedInfos;
            DaresVersatilesInfos = daresVersatilesInfos;
        }

        public DareCreatedListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)DaresFixedInfos.Count);
            for (var daresFixedInfosIndex = 0; daresFixedInfosIndex < DaresFixedInfos.Count; daresFixedInfosIndex++)
            {
                var objectToSend = DaresFixedInfos[daresFixedInfosIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short)DaresVersatilesInfos.Count);
            for (var daresVersatilesInfosIndex = 0; daresVersatilesInfosIndex < DaresVersatilesInfos.Count; daresVersatilesInfosIndex++)
            {
                var objectToSend = DaresVersatilesInfos[daresVersatilesInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var daresFixedInfosCount = reader.ReadUShort();
            DaresFixedInfos = new List<DareInformations>();
            for (var daresFixedInfosIndex = 0; daresFixedInfosIndex < daresFixedInfosCount; daresFixedInfosIndex++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                DaresFixedInfos.Add(objectToAdd);
            }
            var daresVersatilesInfosCount = reader.ReadUShort();
            DaresVersatilesInfos = new List<DareVersatileInformations>();
            for (var daresVersatilesInfosIndex = 0; daresVersatilesInfosIndex < daresVersatilesInfosCount; daresVersatilesInfosIndex++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                DaresVersatilesInfos.Add(objectToAdd);
            }
        }

    }
}
