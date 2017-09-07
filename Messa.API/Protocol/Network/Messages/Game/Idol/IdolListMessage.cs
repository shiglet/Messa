﻿namespace Messa.API.Protocol.Network.Messages.Game.Idol
{
    using Types.Game.Idol;
    using System.Collections.Generic;
    using Utils.IO;

    public class IdolListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6585;
        public override ushort MessageID => ProtocolId;
        public List<ushort> ChosenIdols { get; set; }
        public List<ushort> PartyChosenIdols { get; set; }
        public List<PartyIdol> PartyIdols { get; set; }

        public IdolListMessage(List<ushort> chosenIdols, List<ushort> partyChosenIdols, List<PartyIdol> partyIdols)
        {
            ChosenIdols = chosenIdols;
            PartyChosenIdols = partyChosenIdols;
            PartyIdols = partyIdols;
        }

        public IdolListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ChosenIdols.Count);
            for (var chosenIdolsIndex = 0; chosenIdolsIndex < ChosenIdols.Count; chosenIdolsIndex++)
            {
                writer.WriteVarUhShort(ChosenIdols[chosenIdolsIndex]);
            }
            writer.WriteShort((short)PartyChosenIdols.Count);
            for (var partyChosenIdolsIndex = 0; partyChosenIdolsIndex < PartyChosenIdols.Count; partyChosenIdolsIndex++)
            {
                writer.WriteVarUhShort(PartyChosenIdols[partyChosenIdolsIndex]);
            }
            writer.WriteShort((short)PartyIdols.Count);
            for (var partyIdolsIndex = 0; partyIdolsIndex < PartyIdols.Count; partyIdolsIndex++)
            {
                var objectToSend = PartyIdols[partyIdolsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var chosenIdolsCount = reader.ReadUShort();
            ChosenIdols = new List<ushort>();
            for (var chosenIdolsIndex = 0; chosenIdolsIndex < chosenIdolsCount; chosenIdolsIndex++)
            {
                ChosenIdols.Add(reader.ReadVarUhShort());
            }
            var partyChosenIdolsCount = reader.ReadUShort();
            PartyChosenIdols = new List<ushort>();
            for (var partyChosenIdolsIndex = 0; partyChosenIdolsIndex < partyChosenIdolsCount; partyChosenIdolsIndex++)
            {
                PartyChosenIdols.Add(reader.ReadVarUhShort());
            }
            var partyIdolsCount = reader.ReadUShort();
            PartyIdols = new List<PartyIdol>();
            for (var partyIdolsIndex = 0; partyIdolsIndex < partyIdolsCount; partyIdolsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<PartyIdol>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                PartyIdols.Add(objectToAdd);
            }
        }

    }
}
