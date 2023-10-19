using System;

namespace Inventories.Abstract
{
    public class Apple : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        public Type Type => GetType();

        public Apple(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }
        public IInventoryItem Clone()
        {
            var cloneApple = new Apple(Info);
            cloneApple.State.Amount = State.Amount;
            return cloneApple;
        }
    }
}