using System.Collections.Generic;
using Messa.API.Protocol.Network.Types.Game.Data.Items;

namespace Messa.API.Game.Inventory
{
    public interface IInventory
    {
        List<ObjectItem> Objects { get; set; }
    }
}