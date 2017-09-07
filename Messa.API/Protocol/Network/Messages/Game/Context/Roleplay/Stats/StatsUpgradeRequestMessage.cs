﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Stats
{
    using Utils.IO;

    public class StatsUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5610;
        public override ushort MessageID => ProtocolId;
        public bool UseAdditionnal { get; set; }
        public byte StatId { get; set; }
        public ushort BoostPoint { get; set; }

        public StatsUpgradeRequestMessage(bool useAdditionnal, byte statId, ushort boostPoint)
        {
            UseAdditionnal = useAdditionnal;
            StatId = statId;
            BoostPoint = boostPoint;
        }

        public StatsUpgradeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(UseAdditionnal);
            writer.WriteByte(StatId);
            writer.WriteVarUhShort(BoostPoint);
        }

        public override void Deserialize(IDataReader reader)
        {
            UseAdditionnal = reader.ReadBoolean();
            StatId = reader.ReadByte();
            BoostPoint = reader.ReadVarUhShort();
        }

    }
}
