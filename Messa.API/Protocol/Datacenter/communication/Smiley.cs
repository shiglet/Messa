// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("Smileys")]
    public class Smiley : IDataObject
    {
        public const string MODULE = "Smileys";
        public uint CategoryId;
        public bool ForPlayers;
        public string GfxId;
        public uint Id;
        public uint Order;
        public uint ReferenceId;
        public List<string> Triggers;
    }
}