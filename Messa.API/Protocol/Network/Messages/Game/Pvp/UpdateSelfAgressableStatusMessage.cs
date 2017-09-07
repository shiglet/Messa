﻿namespace Messa.API.Protocol.Network.Messages.Game.Pvp
{
    using Utils.IO;

    public class UpdateSelfAgressableStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6456;
        public override ushort MessageID => ProtocolId;
        public byte Status { get; set; }
        public int ProbationTime { get; set; }

        public UpdateSelfAgressableStatusMessage(byte status, int probationTime)
        {
            Status = status;
            ProbationTime = probationTime;
        }

        public UpdateSelfAgressableStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Status);
            writer.WriteInt(ProbationTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = reader.ReadByte();
            ProbationTime = reader.ReadInt();
        }

    }
}
