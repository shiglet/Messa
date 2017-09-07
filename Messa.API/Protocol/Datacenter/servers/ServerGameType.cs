// Generated on 12/06/2016 11:35:52

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("ServerGameTypes")]
    public class ServerGameType : IDataObject
    {
        public const string MODULE = "ServerGameTypes";
        public string DescriptionId;
        public int Id;
        public uint NameId;
        public string RulesId;
        public bool SelectableByPlayer;
    }
}