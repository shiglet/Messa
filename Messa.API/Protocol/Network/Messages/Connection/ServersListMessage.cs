﻿namespace Messa.API.Protocol.Network.Messages.Connection
{
    using Types.Connection;
    using System.Collections.Generic;
    using Utils.IO;

    public class ServersListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 30;
        public override ushort MessageID => ProtocolId;
        public List<GameServerInformations> Servers { get; set; }
        public ushort AlreadyConnectedToServerId { get; set; }
        public bool CanCreateNewCharacter { get; set; }

        public ServersListMessage(List<GameServerInformations> servers, ushort alreadyConnectedToServerId, bool canCreateNewCharacter)
        {
            Servers = servers;
            AlreadyConnectedToServerId = alreadyConnectedToServerId;
            CanCreateNewCharacter = canCreateNewCharacter;
        }

        public ServersListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Servers.Count);
            for (var serversIndex = 0; serversIndex < Servers.Count; serversIndex++)
            {
                var objectToSend = Servers[serversIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteVarUhShort(AlreadyConnectedToServerId);
            writer.WriteBoolean(CanCreateNewCharacter);
        }

        public override void Deserialize(IDataReader reader)
        {
            var serversCount = reader.ReadUShort();
            Servers = new List<GameServerInformations>();
            for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
            {
                var objectToAdd = new GameServerInformations();
                objectToAdd.Deserialize(reader);
                Servers.Add(objectToAdd);
            }
            AlreadyConnectedToServerId = reader.ReadVarUhShort();
            CanCreateNewCharacter = reader.ReadBoolean();
        }

    }
}
