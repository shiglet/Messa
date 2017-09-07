using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("MountBone")]
    public class MountBone : IDataObject
    {
        public const string MODULE = "MountBone";
        public uint Id;
    }
}