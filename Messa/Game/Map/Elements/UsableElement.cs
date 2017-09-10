using System.Collections.Generic;
using Messa.API.Game.Map.Elements;
using Messa.API.Protocol.Network.Types.Game.Interactive;

namespace Messa.Game.Map.Elements
{
    public class UsableElement : IUsableElement
    {
        public UsableElement(int cellId, IInteractiveElement element, List<InteractiveElementSkill> skills)
        {
            CellId = cellId;
            Element = element;
            Skills = skills;
        }

        public int CellId { get; }
        public IInteractiveElement Element { get; }
        public List<InteractiveElementSkill> Skills { get; }
    }
}