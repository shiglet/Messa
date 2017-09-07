﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildMemberLeavingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5923;
        public override ushort MessageID => ProtocolId;
        public bool Kicked { get; set; }
        public ulong MemberId { get; set; }

        public GuildMemberLeavingMessage(bool kicked, ulong memberId)
        {
            Kicked = kicked;
            MemberId = memberId;
        }

        public GuildMemberLeavingMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Kicked);
            writer.WriteVarUhLong(MemberId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Kicked = reader.ReadBoolean();
            MemberId = reader.ReadVarUhLong();
        }

    }
}
