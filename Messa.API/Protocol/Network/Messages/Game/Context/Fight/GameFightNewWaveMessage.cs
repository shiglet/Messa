﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightNewWaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6490;
        public override ushort MessageID => ProtocolId;
        public byte ObjectId { get; set; }
        public byte TeamId { get; set; }
        public short NbTurnBeforeNextWave { get; set; }

        public GameFightNewWaveMessage(byte objectId, byte teamId, short nbTurnBeforeNextWave)
        {
            ObjectId = objectId;
            TeamId = teamId;
            NbTurnBeforeNextWave = nbTurnBeforeNextWave;
        }

        public GameFightNewWaveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ObjectId);
            writer.WriteByte(TeamId);
            writer.WriteShort(NbTurnBeforeNextWave);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadByte();
            TeamId = reader.ReadByte();
            NbTurnBeforeNextWave = reader.ReadShort();
        }

    }
}
