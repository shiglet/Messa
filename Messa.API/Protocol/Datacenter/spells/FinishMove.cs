// Generated on 12/06/2016 11:35:52

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("FinishMoves")]
    public class FinishMove : IDataObject
    {
        public const string MODULE = "FinishMoves";
        public int Category;
        public int Duration;
        public bool Free;
        public int Id;
        public uint NameId;
        public int SpellLevel;
    }
}