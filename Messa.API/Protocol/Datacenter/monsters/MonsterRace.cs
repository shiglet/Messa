// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("MonsterRaces")]
    public class MonsterRace : IDataObject
    {
        public const string MODULE = "MonsterRaces";
        public int Id;
        public List<uint> Monsters;
        public uint NameId;
        public int SuperRaceId;
    }
}