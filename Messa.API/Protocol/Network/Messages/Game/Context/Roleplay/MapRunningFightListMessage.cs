﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.Context.Fight;
    using System.Collections.Generic;
    using Utils.IO;

    public class MapRunningFightListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5743;
        public override ushort MessageID => ProtocolId;
        public List<FightExternalInformations> Fights { get; set; }

        public MapRunningFightListMessage(List<FightExternalInformations> fights)
        {
            Fights = fights;
        }

        public MapRunningFightListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Fights.Count);
            for (var fightsIndex = 0; fightsIndex < Fights.Count; fightsIndex++)
            {
                var objectToSend = Fights[fightsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var fightsCount = reader.ReadUShort();
            Fights = new List<FightExternalInformations>();
            for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
            {
                var objectToAdd = new FightExternalInformations();
                objectToAdd.Deserialize(reader);
                Fights.Add(objectToAdd);
            }
        }

    }
}
