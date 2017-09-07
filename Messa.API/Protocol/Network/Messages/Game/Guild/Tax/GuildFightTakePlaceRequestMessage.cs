﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
    {
        public new const ushort ProtocolId = 6235;
        public override ushort MessageID => ProtocolId;
        public int ReplacedCharacterId { get; set; }

        public GuildFightTakePlaceRequestMessage(int replacedCharacterId)
        {
            ReplacedCharacterId = replacedCharacterId;
        }

        public GuildFightTakePlaceRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ReplacedCharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ReplacedCharacterId = reader.ReadInt();
        }

    }
}
