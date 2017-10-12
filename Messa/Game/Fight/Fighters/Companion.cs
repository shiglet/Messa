using Messa.API.Game.Fight.Fighters;
using Messa.API.Gamedata;
using Messa.API.Protocol.Network.Types.Game.Context.Fight;

namespace Messa.Game.Fight.Fighters
{
    public class Companion : Fighter, ICompanion
    {
        public Companion(double id, int cellId, GameFightMinimalStats stats, uint teamId, bool isAlive,
            byte companionGenericId, int level, double masterId) : base(id, cellId, stats, teamId, isAlive)
        {
            Level = level;
            CompanionGenericId = companionGenericId;
            MasterId = masterId;
            Name = D2OParsing.GetMonsterName(CompanionGenericId);
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public byte CompanionGenericId { get; set; }
        public double MasterId { get; set; }
    }
}