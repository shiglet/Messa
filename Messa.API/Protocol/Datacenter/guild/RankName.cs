using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("RankNames")]
    public class RankName : IDataObject
    {
        public const string MODULE = "RankNames";
        public int Id;
        public uint NameId;
        public int Order;
    }
}