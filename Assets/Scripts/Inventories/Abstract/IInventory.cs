using System;

namespace Inventories.Abstract
{
    public interface IInventory
    {
        int Capacity { get; set; }
        bool IsFul { get; }

        IInventoryItem GetItem(Type itemType);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(Type type);
        IInventoryItem[] GetEquippedItems();
        int GetItemAmount(Type itemType);

        bool TryToAdd(object sender, IInventoryItem item);
        void Remove(object sender, Type itemType, int amount = 1);
        bool HasItem(Type type, out IInventoryItem item);
    }
}