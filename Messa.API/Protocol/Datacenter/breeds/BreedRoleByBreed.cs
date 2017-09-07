// Generated on 12/06/2016 11:35:50

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("BreedRoleByBreeds")]
    public class BreedRoleByBreed : IDataObject
    {
        public const string MODULE = "BreedRoleByBreeds";
        public int BreedId;
        public uint DescriptionId;
        public int Order;
        public int RoleId;
        public int Value;
    }
}