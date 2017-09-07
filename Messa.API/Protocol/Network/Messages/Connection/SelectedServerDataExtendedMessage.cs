﻿namespace Messa.API.Protocol.Network.Messages.Connection
{
    using Types.Connection;
    using System.Collections.Generic;
    using Utils.IO;

    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public new const ushort ProtocolId = 6469;
        public override ushort MessageID => ProtocolId;
        public List<GameServerInformations> Servers { get; set; }

        public SelectedServerDataExtendedMessage(List<GameServerInformations> servers)
        {
            Servers = servers;
        }

        public SelectedServerDataExtendedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Servers.Count);
            for (var serversIndex = 0; serversIndex < Servers.Count; serversIndex++)
            {
                var objectToSend = Servers[serversIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var serversCount = reader.ReadUShort();
            Servers = new List<GameServerInformations>();
            for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
            {
                var objectToAdd = new GameServerInformations();
                objectToAdd.Deserialize(reader);
                Servers.Add(objectToAdd);
            }
        }

    }
}
