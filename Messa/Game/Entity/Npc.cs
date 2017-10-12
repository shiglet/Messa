using Messa.API.Game.Entity;
using Messa.API.Gamedata.D2i;
using Messa.API.Gamedata.D2o;

namespace Messa.Game.Entity
{
    public class Npc : INpc, IEntity
    {
        public Npc(int cell, double id, int npcid)
        {
            CellId = cell;
            Id = id;
            NpcId = npcid;
        }

        public int CellId { get; set; }

        public double Id { get; set; }

        public int NpcId { get; set; }

        public string Name => FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<API.Datacenter.Npc>(NpcId)
            .NameId);
    }
}