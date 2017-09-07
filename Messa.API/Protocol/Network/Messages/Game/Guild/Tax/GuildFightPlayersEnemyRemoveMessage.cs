﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5929;
        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public ulong PlayerId { get; set; }

        public GuildFightPlayersEnemyRemoveMessage(int fightId, ulong playerId)
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public GuildFightPlayersEnemyRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
