// Generated on 12/06/2016 11:35:51

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("CompanionSpells")]
    public class CompanionSpell : IDataObject
    {
        public const string MODULE = "CompanionSpells";
        public int CompanionId;
        public string GradeByLevel;
        public int Id;
        public int SpellId;
    }
}