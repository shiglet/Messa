// Generated on 12/06/2016 11:35:49

using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("Titles")]
    public class Title : IDataObject
    {
        public const string MODULE = "Titles";
        public int CategoryId;
        public int Id;
        public uint NameFemaleId;
        public uint NameMaleId;
        public bool Visible;
    }
}