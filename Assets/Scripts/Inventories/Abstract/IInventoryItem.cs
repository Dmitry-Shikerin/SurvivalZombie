using System;
using UnityEditorInternal.Profiling.Memory.Experimental;

namespace Inventories.Abstract
{
    public interface IInventoryItem
    {
        IInventoryItemInfo Info { get; }
        IInventoryItemState State { get; }
        Type Type { get; }

        IInventoryItem Clone();
    }
}