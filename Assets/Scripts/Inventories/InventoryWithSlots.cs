using System;
using System.Collections.Generic;
using System.Linq;
using Inventories.Abstract;
using UnityEngine;

namespace Inventories
{
    public class InventoryWithSlots : IInventory
    {
        private List<IInventorySlot> _slots;

        public InventoryWithSlots(int capacity)
        {
            Capacity = capacity;
            _slots = new List<IInventorySlot>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }

        public event Action<object, IInventoryItem, int> OnInventoryItemAdded;
        public event Action<object, Type, int> OnInventoryItemRemoved;
        public event Action<object> OnInventoryStateChanged;
        
        public int Capacity { get; set; }
        public bool IsFul => _slots.All(slot => slot.IsFull);

        
        public IInventoryItem GetItem(Type itemType)
        {
            return _slots.Find(slot => slot.ItemType == itemType).Item;
        }

        public IInventoryItem[] GetAllItems()
        {
            List<IInventoryItem> allItems = new List<IInventoryItem>();
            
            foreach (IInventorySlot slot in _slots)
            {
                if (slot.IsEmpty == false)
                {
                    allItems.Add(slot.Item);
                }
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            List<IInventoryItem> allItemsOfType = new List<IInventoryItem>();
            List<IInventorySlot> slotsOfType =
                _slots.FindAll(slot => slot.IsEmpty == false && slot.ItemType == itemType);
            
            foreach (IInventorySlot slot in slotsOfType)
            {
                if (slot.IsEmpty == false)
                {
                    allItemsOfType.Add(slot.Item);
                }
            }

            return allItemsOfType.ToArray();
        }

        public IInventoryItem[] GetEquippedItems()
        {
            List<IInventorySlot> requiredSlots =
                _slots.FindAll(slot => slot.IsEmpty == false && slot.Item.State.IsEquipped);
            List<IInventoryItem> equippedItems = new List<IInventoryItem>();
            
            foreach (IInventorySlot slot in requiredSlots)
            {
                if (slot.IsEmpty == false)
                {
                    equippedItems.Add(slot.Item);
                }
            }

            return equippedItems.ToArray();
        }

        public int GetItemAmount(Type itemType)
        {
            int amount = 0;
            List<IInventorySlot> allItemSlots =
                _slots.FindAll(slot => slot.ItemType == itemType);
            
            foreach (IInventorySlot itemSlot in allItemSlots)
            {
                amount += itemSlot.Amount;
            }

            return amount;
        }

        public bool TryToAdd(object sender, IInventoryItem item)
        {
            var slotWithSameItemButNotEmpty =
                _slots.Find(slot => slot.IsEmpty == false && slot.ItemType == item.Type &&
                                    slot.IsFull == false);

            if (slotWithSameItemButNotEmpty != null)
                return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);

            var emptySlot = _slots.Find(slot => slot.IsEmpty);
            
            if (emptySlot != null)
                return TryToAddToSlot(sender, emptySlot, item);
            
            Debug.Log($"Невозможно добавить предмет: {item.Type}, инвентарь заполнен" +
                      $", amount: {item.State.Amount}, ");

            return false;
        }
        
        public bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            bool fits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventorySlot;
            int amountToAdd = fits ? item.State.Amount : item.Info.MaxItemsInInventorySlot - slot.Amount;
            int amountLeft = item.State.Amount - amountToAdd;

            var clonedItem = item.Clone();
            clonedItem.State.Amount = amountToAdd;

            if (slot.IsEmpty)
                slot.SetItem(clonedItem);
            else
                slot.Item.State.Amount += amountToAdd;
            
            Debug.Log($"Предмет: {item.Type}, добавлен в корзину" +
                      $", amount: {amountToAdd}, ");
            OnInventoryItemAdded?.Invoke(sender, item, amountToAdd);
            OnInventoryStateChanged?.Invoke(sender);

            if (amountLeft <= 0)
                return true;

            item.State.Amount = amountLeft;
            return TryToAdd(sender, item);
        }

        public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
        {
            //добавил
            if (fromSlot == toSlot)
                return;
            
            if (fromSlot.IsEmpty)
                return;

            if (toSlot.IsFull)
                return;

            if (toSlot.IsEmpty == false && fromSlot.ItemType != toSlot.ItemType)
                return;

            int slotCapacity = fromSlot.Capacity;
            bool fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
            int amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
            var amountLeft = fromSlot.Amount - amountToAdd;

            if (toSlot.IsEmpty)
            {
                toSlot.SetItem(fromSlot.Item);
                fromSlot.Clear();
                OnInventoryStateChanged?.Invoke(sender);
            }

            toSlot.Item.State.Amount += amountToAdd;

            if (fits)
            {
                fromSlot.Clear();
            }
            else
            {
                fromSlot.Item.State.Amount = amountLeft;
            }
            
            OnInventoryStateChanged?.Invoke(sender);
        }

        public void Remove(object sender, Type itemType, int amount = 1)
        {
            IInventorySlot[] slotsWithItem = GetAllSlots(itemType);

            if (slotsWithItem.Length == 0)
                return;

            int amountToRemove = amount;
            int count = slotsWithItem.Length;

            for (int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];

                if (slot.Amount >= amountToRemove)
                {
                    slot.Item.State.Amount -= amountToRemove;
                    
                    if(slot.Amount <= 0)
                        slot.Clear();
                    
                    Debug.Log($"Айтем удален из инвентаря. Тип айтема: {itemType}" +
                              $", amount: {amountToRemove}, ");
                    OnInventoryItemRemoved?.Invoke(sender, itemType, amountToRemove);
                    OnInventoryStateChanged?.Invoke(sender);
                    
                    break;
                }

                var amountRemoved = slot.Amount;
                amountToRemove -= slot.Amount;
                slot.Clear();
                Debug.Log($"Айтем удален из инвентаря. Тип айтема: {itemType}" +
                          $", amount: {amountRemoved}, ");
                OnInventoryItemRemoved?.Invoke(sender, itemType, amountRemoved);
                OnInventoryStateChanged?.Invoke(sender);
            }
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            item = GetItem(type);
            return item != null;
        }
        
        public IInventorySlot[] GetAllSlots(Type itemType)
        {
            return _slots.FindAll(slot => slot.IsEmpty == false && 
                                          slot.ItemType == itemType).ToArray();
        }

        public IInventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }
    }
}