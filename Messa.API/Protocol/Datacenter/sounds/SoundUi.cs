// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("SoundUi")]
    public class SoundUi : IDataObject
    {
        public string CloseFile;
        public uint Id;
        public string MODULE = "SoundUi";
        public string OpenFile;
        public List<SoundUiElement> SubElements;
        public string UiName;
    }
}