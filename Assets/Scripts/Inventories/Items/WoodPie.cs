using System;
using Inventories.Abstract;

namespace Inventories.Items
{
    public class WoodPie : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        public Type Type { get; }

        public WoodPie(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }
        
        public IInventoryItem Clone()
        {
            var clonedWoodPie = new WoodPie(Info);
            clonedWoodPie.State.Amount = State.Amount;
            return clonedWoodPie;
        }
    }
}