namespace Messa.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Character.Alignment;
    using Utils.IO;

    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public new const ushort ProtocolId = 203;
        public override ushort TypeID => ProtocolId;
        public ActorAlignmentInformations AlignmentInfos { get; set; }

        public GameFightMonsterWithAlignmentInformations(ActorAlignmentInformations alignmentInfos)
        {
            AlignmentInfos = alignmentInfos;
        }

        public GameFightMonsterWithAlignmentInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }

    }
}
