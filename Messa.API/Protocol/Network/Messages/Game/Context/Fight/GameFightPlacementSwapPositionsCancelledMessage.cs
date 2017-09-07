﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightPlacementSwapPositionsCancelledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6546;
        public override ushort MessageID => ProtocolId;
        public int RequestId { get; set; }
        public double CancellerId { get; set; }

        public GameFightPlacementSwapPositionsCancelledMessage(int requestId, double cancellerId)
        {
            RequestId = requestId;
            CancellerId = cancellerId;
        }

        public GameFightPlacementSwapPositionsCancelledMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequestId);
            writer.WriteDouble(CancellerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadInt();
            CancellerId = reader.ReadDouble();
        }

    }
}
