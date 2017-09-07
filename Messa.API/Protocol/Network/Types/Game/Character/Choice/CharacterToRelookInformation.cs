namespace Messa.API.Protocol.Network.Types.Game.Character.Choice
{
    using Utils.IO;

    public class CharacterToRelookInformation : AbstractCharacterToRefurbishInformation
    {
        public new const ushort ProtocolId = 399;
        public override ushort TypeID => ProtocolId;

        public CharacterToRelookInformation() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
