﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class MonsterInGroupLightInformations : NetworkType
    {
        public const ushort ProtocolId = 395;
        public override ushort TypeID => ProtocolId;
        public int CreatureGenericId { get; set; }
        public byte Grade { get; set; }

        public MonsterInGroupLightInformations(int creatureGenericId, byte grade)
        {
            CreatureGenericId = creatureGenericId;
            Grade = grade;
        }

        public MonsterInGroupLightInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(CreatureGenericId);
            writer.WriteByte(Grade);
        }

        public override void Deserialize(IDataReader reader)
        {
            CreatureGenericId = reader.ReadInt();
            Grade = reader.ReadByte();
        }

    }
}
