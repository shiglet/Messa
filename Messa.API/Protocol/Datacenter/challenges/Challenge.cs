// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("Challenge")]
    public class Challenge : IDataObject
    {
        public const string MODULE = "Challenge";
        public bool DareAvailable;
        public uint DescriptionId;
        public int Id;
        public List<uint> IncompatibleChallenges;
        public uint NameId;
    }
}