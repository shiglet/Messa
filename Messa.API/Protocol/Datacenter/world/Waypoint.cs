// Generated on 12/06/2016 11:35:52

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("Waypoints")]
    public class Waypoint : IDataObject
    {
        public const string MODULE = "Waypoints";
        public uint Id;
        public uint MapId;
        public uint SubAreaId;
    }
}