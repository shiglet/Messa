﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Character;
    using Types.Game.Social;
    using System.Collections.Generic;
    using Utils.IO;

    public class GuildFactsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6415;
        public override ushort MessageID => ProtocolId;
        public GuildFactSheetInformations Infos { get; set; }
        public int CreationDate { get; set; }
        public ushort NbTaxCollectors { get; set; }
        public List<CharacterMinimalInformations> Members { get; set; }

        public GuildFactsMessage(GuildFactSheetInformations infos, int creationDate, ushort nbTaxCollectors, List<CharacterMinimalInformations> members)
        {
            Infos = infos;
            CreationDate = creationDate;
            NbTaxCollectors = nbTaxCollectors;
            Members = members;
        }

        public GuildFactsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Infos.TypeID);
            Infos.Serialize(writer);
            writer.WriteInt(CreationDate);
            writer.WriteVarUhShort(NbTaxCollectors);
            writer.WriteShort((short)Members.Count);
            for (var membersIndex = 0; membersIndex < Members.Count; membersIndex++)
            {
                var objectToSend = Members[membersIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance<GuildFactSheetInformations>(reader.ReadUShort());
            Infos.Deserialize(reader);
            CreationDate = reader.ReadInt();
            NbTaxCollectors = reader.ReadVarUhShort();
            var membersCount = reader.ReadUShort();
            Members = new List<CharacterMinimalInformations>();
            for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
            {
                var objectToAdd = new CharacterMinimalInformations();
                objectToAdd.Deserialize(reader);
                Members.Add(objectToAdd);
            }
        }

    }
}
