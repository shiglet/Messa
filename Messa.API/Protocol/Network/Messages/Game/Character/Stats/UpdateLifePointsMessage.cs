﻿namespace Messa.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Utils.IO;

    public class UpdateLifePointsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5658;
        public override ushort MessageID => ProtocolId;
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }

        public UpdateLifePointsMessage(uint lifePoints, uint maxLifePoints)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
        }

        public UpdateLifePointsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
        }

        public override void Deserialize(IDataReader reader)
        {
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
        }

    }
}
