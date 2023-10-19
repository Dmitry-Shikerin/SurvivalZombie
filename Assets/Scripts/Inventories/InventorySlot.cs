using System;
using Inventories.Abstract;

namespace Inventories
{
    public class InventorySlot : IInventorySlot
    {
        public bool IsFull => IsEmpty == false && Amount == Capacity;
        public bool IsEmpty => Item == null;
        public IInventoryItem Item { get; private set; }
        public Type ItemType => Item.Type;
        public int Amount => IsEmpty ? 0 : Item.State.Amount;
        public int Capacity { get; private set; }
        
        public void SetItem(IInventoryItem item)
        {
            if (IsEmpty == false)
                return;

            Item = item;
            Capacity = item.Info.MaxItemsInInventorySlot;
        }

        public void Clear()
        {
            if(IsEmpty)
                return;

            Item.State.Amount = 0;
            Item = null;
        }
    }
}