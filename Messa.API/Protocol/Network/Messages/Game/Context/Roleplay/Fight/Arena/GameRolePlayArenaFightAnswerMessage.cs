﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    using Utils.IO;

    public class GameRolePlayArenaFightAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6279;
        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public bool Accept { get; set; }

        public GameRolePlayArenaFightAnswerMessage(int fightId, bool accept)
        {
            FightId = fightId;
            Accept = accept;
        }

        public GameRolePlayArenaFightAnswerMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            Accept = reader.ReadBoolean();
        }

    }
}
