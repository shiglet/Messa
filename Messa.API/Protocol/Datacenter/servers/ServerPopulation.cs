// Generated on 12/06/2016 11:35:52

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("ServerPopulations")]
    public class ServerPopulation : IDataObject
    {
        public const string MODULE = "ServerPopulations";
        public int Id;
        public uint NameId;
        public int Weight;
    }
}