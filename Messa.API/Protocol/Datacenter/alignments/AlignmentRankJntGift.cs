// Generated on 12/06/2016 11:35:49

using System.Collections.Generic;
using Messa.API.Gamedata.D2o;

namespace Messa.API.Datacenter
{
    [D2oClass("AlignmentRankJntGift")]
    public class AlignmentRankJntGift : IDataObject
    {
        public const string MODULE = "AlignmentRankJntGift";
        public List<int> Gifts;
        public int Id;
        public List<int> Levels;
        public List<int> Parameters;
    }
}