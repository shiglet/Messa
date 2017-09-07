﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using Types.Game.House;
    using System.Collections.Generic;
    using Utils.IO;

    public class HousePropertiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5734;
        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public List<int> DoorsOnMap { get; set; }
        public HouseInstanceInformations Properties { get; set; }

        public HousePropertiesMessage(uint houseId, List<int> doorsOnMap, HouseInstanceInformations properties)
        {
            HouseId = houseId;
            DoorsOnMap = doorsOnMap;
            Properties = properties;
        }

        public HousePropertiesMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteShort((short)DoorsOnMap.Count);
            for (var doorsOnMapIndex = 0; doorsOnMapIndex < DoorsOnMap.Count; doorsOnMapIndex++)
            {
                writer.WriteInt(DoorsOnMap[doorsOnMapIndex]);
            }
            writer.WriteUShort(Properties.TypeID);
            Properties.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            var doorsOnMapCount = reader.ReadUShort();
            DoorsOnMap = new List<int>();
            for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
            {
                DoorsOnMap.Add(reader.ReadInt());
            }
            Properties = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadUShort());
            Properties.Deserialize(reader);
        }

    }
}
