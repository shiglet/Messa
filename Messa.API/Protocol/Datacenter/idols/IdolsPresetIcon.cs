using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("IdolsPresetIcons")]
    public class IdolsPresetIcon
    {
        public const string MODULE = "IdolsPresetIcons";
        public int Id;
        public int Order;
    }
}