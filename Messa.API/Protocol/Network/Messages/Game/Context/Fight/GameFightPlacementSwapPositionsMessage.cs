namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightPlacementSwapPositionsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6544;
        public override ushort MessageID => ProtocolId;

        public GameFightPlacementSwapPositionsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
