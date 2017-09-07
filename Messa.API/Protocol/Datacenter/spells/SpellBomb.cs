// Generated on 12/06/2016 11:35:52

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("SpellBombs")]
    public class SpellBomb : IDataObject
    {
        public const string MODULE = "SpellBombs";
        public int ChainReactionSpellId;
        public int ComboCoeff;
        public int ExplodSpellId;
        public int Id;
        public int InstantSpellId;
        public int WallId;
    }
}