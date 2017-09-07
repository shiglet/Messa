﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTurnStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 714;
        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }
        public uint WaitTime { get; set; }

        public GameFightTurnStartMessage(double objectId, uint waitTime)
        {
            ObjectId = objectId;
            WaitTime = waitTime;
        }

        public GameFightTurnStartMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            writer.WriteVarUhInt(WaitTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            WaitTime = reader.ReadVarUhInt();
        }

    }
}
