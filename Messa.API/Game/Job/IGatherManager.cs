using System.Collections.Generic;

namespace Messa.API.Game.Job
{
    public interface IGatherManager
    {
        List<int> BannedElementId { get; set; }

        bool GoGather(int elemTypeId);
    }
}