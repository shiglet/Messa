// Generated on 12/06/2016 11:35:49

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("Bonuses")]
    public class Bonus : IDataObject
    {
        public const string MODULE = "Bonuses";
        public int Amount;
        public List<int> CriterionsIds;
        public int Id;
        public uint Type;
    }
}