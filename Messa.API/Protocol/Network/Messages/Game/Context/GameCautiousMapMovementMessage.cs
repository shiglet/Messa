namespace Messa.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameCautiousMapMovementMessage : GameMapMovementMessage
    {
        public new const ushort ProtocolId = 6497;
        public override ushort MessageID => ProtocolId;

        public GameCautiousMapMovementMessage() { }

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
