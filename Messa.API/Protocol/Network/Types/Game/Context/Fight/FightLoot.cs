﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using Utils.IO;

    public class FightLoot : NetworkType
    {
        public const ushort ProtocolId = 41;
        public override ushort TypeID => ProtocolId;
        public List<ushort> Objects { get; set; }
        public ulong Kamas { get; set; }

        public FightLoot(List<ushort> objects, ulong kamas)
        {
            Objects = objects;
            Kamas = kamas;
        }

        public FightLoot() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Objects.Count);
            for (var objectsIndex = 0; objectsIndex < Objects.Count; objectsIndex++)
            {
                writer.WriteVarUhShort(Objects[objectsIndex]);
            }
            writer.WriteVarUhLong(Kamas);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsCount = reader.ReadUShort();
            Objects = new List<ushort>();
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
            {
                Objects.Add(reader.ReadVarUhShort());
            }
            Kamas = reader.ReadVarUhLong();
        }

    }
}
