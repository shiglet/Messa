﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Objects
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ObjectGroundRemovedMultipleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5944;
        public override ushort MessageID => ProtocolId;
        public List<ushort> Cells { get; set; }

        public ObjectGroundRemovedMultipleMessage(List<ushort> cells)
        {
            Cells = cells;
        }

        public ObjectGroundRemovedMultipleMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Cells.Count);
            for (var cellsIndex = 0; cellsIndex < Cells.Count; cellsIndex++)
            {
                writer.WriteVarUhShort(Cells[cellsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var cellsCount = reader.ReadUShort();
            Cells = new List<ushort>();
            for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
            {
                Cells.Add(reader.ReadVarUhShort());
            }
        }

    }
}
