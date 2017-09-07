﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class ChallengeFightJoinRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5908;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }
        public sbyte Reason { get; set; }

        public ChallengeFightJoinRefusedMessage(ulong playerId, sbyte reason)
        {
            PlayerId = playerId;
            Reason = reason;
        }

        public ChallengeFightJoinRefusedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            Reason = reader.ReadSByte();
        }

    }
}
