// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("NpcMessages")]
    public class NpcMessage : IDataObject
    {
        public const string MODULE = "NpcMessages";
        public int Id;
        public uint MessageId;
        public List<string> MessageParams;
    }
}