﻿namespace Messa.API.Protocol.Network.Types.Game.Character.Alignment
{
    using Utils.IO;

    public class ActorAlignmentInformations : NetworkType
    {
        public const ushort ProtocolId = 201;
        public override ushort TypeID => ProtocolId;
        public sbyte AlignmentSide { get; set; }
        public byte AlignmentValue { get; set; }
        public byte AlignmentGrade { get; set; }
        public double CharacterPower { get; set; }

        public ActorAlignmentInformations(sbyte alignmentSide, byte alignmentValue, byte alignmentGrade, double characterPower)
        {
            AlignmentSide = alignmentSide;
            AlignmentValue = alignmentValue;
            AlignmentGrade = alignmentGrade;
            CharacterPower = characterPower;
        }

        public ActorAlignmentInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(AlignmentSide);
            writer.WriteByte(AlignmentValue);
            writer.WriteByte(AlignmentGrade);
            writer.WriteDouble(CharacterPower);
        }

        public override void Deserialize(IDataReader reader)
        {
            AlignmentSide = reader.ReadSByte();
            AlignmentValue = reader.ReadByte();
            AlignmentGrade = reader.ReadByte();
            CharacterPower = reader.ReadDouble();
        }

    }
}
