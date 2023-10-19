using System;
using Inventories.Abstract;

namespace Inventories
{
    [Serializable]
    public class InventoryItemState : IInventoryItemState
    {
        public int ItemAmount;
        public bool IsItemEquipped;

        public InventoryItemState()
        {
            ItemAmount = 0;
            IsItemEquipped = false;
        }
        
        public int Amount { get => ItemAmount; set => ItemAmount = value; }
        public bool IsEquipped { get => IsItemEquipped; set => IsItemEquipped = value; }
    }
}