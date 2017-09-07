﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightPlacementSwapPositionsAcceptMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6547;
        public override ushort MessageID => ProtocolId;
        public int RequestId { get; set; }

        public GameFightPlacementSwapPositionsAcceptMessage(int requestId)
        {
            RequestId = requestId;
        }

        public GameFightPlacementSwapPositionsAcceptMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
        }

    }
}
