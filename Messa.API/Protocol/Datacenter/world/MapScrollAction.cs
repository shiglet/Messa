// Generated on 12/06/2016 11:35:52

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("MapScrollActions")]
    public class MapScrollAction : IDataObject
    {
        public const string MODULE = "MapScrollActions";
        public bool BottomExists;
        public int BottomMapId;
        public int Id;
        public bool LeftExists;
        public int LeftMapId;
        public bool RightExists;
        public int RightMapId;
        public bool TopExists;
        public int TopMapId;
    }
}