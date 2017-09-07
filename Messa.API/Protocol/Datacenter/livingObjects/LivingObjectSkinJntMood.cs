// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("LivingObjectSkinJntMood")]
    public class LivingObjectSkinJntMood : IDataObject
    {
        public const string MODULE = "LivingObjectSkinJntMood";
        public List<List<int>> Moods;
        public int SkinId;
    }
}