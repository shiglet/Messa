﻿namespace Messa.API.Protocol.Network.Messages.Game.Approach
{
    using Types.Game.Approach;
    using System.Collections.Generic;
    using Utils.IO;

    public class ServerSessionConstantsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6434;
        public override ushort MessageID => ProtocolId;
        public List<ServerSessionConstant> Variables { get; set; }

        public ServerSessionConstantsMessage(List<ServerSessionConstant> variables)
        {
            Variables = variables;
        }

        public ServerSessionConstantsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Variables.Count);
            for (var variablesIndex = 0; variablesIndex < Variables.Count; variablesIndex++)
            {
                var objectToSend = Variables[variablesIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var variablesCount = reader.ReadUShort();
            Variables = new List<ServerSessionConstant>();
            for (var variablesIndex = 0; variablesIndex < variablesCount; variablesIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ServerSessionConstant>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Variables.Add(objectToAdd);
            }
        }

    }
}
