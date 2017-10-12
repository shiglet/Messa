using Messa.API.Game.Fight.Fighters;
using Messa.API.Gamedata;
using Messa.API.Protocol.Network.Types.Game.Context.Fight;

namespace Messa.Game.Fight.Fighters
{
    public class Monster : Fighter, IMonster
    {
        public Monster(double id, int cellId, GameFightMinimalStats stats, uint teamId, bool isAlive,
            ushort creatureGenericId, byte creatureGrade) : base(id, cellId, stats, teamId, isAlive)
        {
            CreatureGenericId = creatureGenericId;
            CreatureGrade = creatureGrade;
            Name = D2OParsing.GetMonsterName(creatureGenericId);
        }

        public ushort CreatureGenericId { get; set; }
        public byte CreatureGrade { get; set; }
        public string Name { get; set; }
    }
}