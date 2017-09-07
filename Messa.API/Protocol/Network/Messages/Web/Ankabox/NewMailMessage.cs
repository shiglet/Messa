﻿namespace Messa.API.Protocol.Network.Messages.Web.Ankabox
{
    using System.Collections.Generic;
    using Utils.IO;

    public class NewMailMessage : MailStatusMessage
    {
        public new const ushort ProtocolId = 6292;
        public override ushort MessageID => ProtocolId;
        public List<int> SendersAccountId { get; set; }

        public NewMailMessage(List<int> sendersAccountId)
        {
            SendersAccountId = sendersAccountId;
        }

        public NewMailMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)SendersAccountId.Count);
            for (var sendersAccountIdIndex = 0; sendersAccountIdIndex < SendersAccountId.Count; sendersAccountIdIndex++)
            {
                writer.WriteInt(SendersAccountId[sendersAccountIdIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var sendersAccountIdCount = reader.ReadUShort();
            SendersAccountId = new List<int>();
            for (var sendersAccountIdIndex = 0; sendersAccountIdIndex < sendersAccountIdCount; sendersAccountIdIndex++)
            {
                SendersAccountId.Add(reader.ReadInt());
            }
        }

    }
}
