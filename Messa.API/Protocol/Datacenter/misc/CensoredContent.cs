// Generated on 12/06/2016 11:35:51

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("CensoredContents")]
    public class CensoredContent : IDataObject
    {
        public const string MODULE = "CensoredContents";
        public string Lang;
        public int NewValue;
        public int OldValue;
        public int Type;
    }
}