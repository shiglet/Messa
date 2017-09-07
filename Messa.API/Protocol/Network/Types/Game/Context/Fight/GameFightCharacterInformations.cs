﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Character.Alignment;
    using Utils.IO;

    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public new const ushort ProtocolId = 46;
        public override ushort TypeID => ProtocolId;
        public byte Level { get; set; }
        public ActorAlignmentInformations AlignmentInfos { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }

        public GameFightCharacterInformations(byte level, ActorAlignmentInformations alignmentInfos, sbyte breed, bool sex)
        {
            Level = level;
            AlignmentInfos = alignmentInfos;
            Breed = breed;
            Sex = sex;
        }

        public GameFightCharacterInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
            AlignmentInfos.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }

    }
}
