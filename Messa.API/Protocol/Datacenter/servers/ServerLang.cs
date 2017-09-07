using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("ServerLang")]
    public class ServerLang : IDataObject
    {
        public const string MODULE = "ServerLang";
        public int Id;
        public string LangCode;
        public uint NameId;
    }
}