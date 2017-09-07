﻿namespace Messa.API.Protocol.Network.Messages.Game.Approach
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ReloginTokenStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6539;
        public override ushort MessageID => ProtocolId;
        public bool ValidToken { get; set; }
        public List<sbyte> Ticket { get; set; }

        public ReloginTokenStatusMessage(bool validToken, List<sbyte> ticket)
        {
            ValidToken = validToken;
            Ticket = ticket;
        }

        public ReloginTokenStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ValidToken);
            writer.WriteVarInt(Ticket.Count);
            for (var ticketIndex = 0; ticketIndex < Ticket.Count; ticketIndex++)
            {
                writer.WriteSByte(Ticket[ticketIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            ValidToken = reader.ReadBoolean();
            var ticketCount = reader.ReadVarInt();
            Ticket = new List<sbyte>();
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
            {
                Ticket.Add(reader.ReadSByte());
            }
        }

    }
}
