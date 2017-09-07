using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("ChatChannels")]
    public class ChatChannel : IDataObject
    {
        public const string MODULE = "ChatChannels";
        public bool AllowObjects;
        public uint DescriptionId;
        public uint Id;
        public bool IsPrivate;
        public uint NameId;
        public string Shortcut;
        public string ShortcutKey;
    }
}