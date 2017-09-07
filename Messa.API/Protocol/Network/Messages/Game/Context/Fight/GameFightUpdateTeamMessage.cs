﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Types.Game.Context.Fight;
    using Utils.IO;

    public class GameFightUpdateTeamMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5572;
        public override ushort MessageID => ProtocolId;
        public short FightId { get; set; }
        public FightTeamInformations Team { get; set; }

        public GameFightUpdateTeamMessage(short fightId, FightTeamInformations team)
        {
            FightId = fightId;
            Team = team;
        }

        public GameFightUpdateTeamMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(FightId);
            Team.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadShort();
            Team = new FightTeamInformations();
            Team.Deserialize(reader);
        }

    }
}
