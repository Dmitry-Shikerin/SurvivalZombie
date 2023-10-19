using System.Collections.Generic;
using Inventories;
using Inventories.Abstract;
using UnityEngine;

namespace UI.Inventorys.Inventory
{
    public class UIInventoryTester
    {
        private InventoryItemInfo _appleInfo;
        private InventoryItemInfo _pepperInfo;
        private UIInventorySlot[] _uiSlots;
        
        public InventoryWithSlots Inventory { get; }

        public UIInventoryTester
        (
            InventoryItemInfo appleInfo,
            InventoryItemInfo pepperInfo,
            UIInventorySlot[] uiSlots
        )
        {
            _appleInfo = appleInfo;
            _pepperInfo = pepperInfo;
            _uiSlots = uiSlots;

            Inventory = new InventoryWithSlots(15);
            Inventory.OnInventoryStateChanged += OnInventoryStateChanged;
        }

        public void FillSlots()
        {
            var allSlots = Inventory.GetAllSlots();
            var availableSlots = new List<IInventorySlot>(allSlots);

            int filledSlots = 5;

            for (int i = 0; i < filledSlots; i++)
            {
                var filledSlot = AddRandomApplesIntoRandomSlot(availableSlots);
                availableSlots.Remove(filledSlot);
                
                filledSlot = AddRandomPeppersIntoRandomSlot(availableSlots);
                availableSlots.Remove(filledSlot);
            }
            
            SetUpInventoryUI(Inventory);
        }

        private IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
        {
            int randomSlotIndex = Random.Range(0, slots.Count);
            IInventorySlot randomSlot = slots[randomSlotIndex];
            int randomCount = Random.Range(1, 4);
            Apple apple = new Apple(_appleInfo);
            apple.State.Amount = randomCount;
            Inventory.TryToAddToSlot(this, randomSlot, apple);
            return randomSlot;
        }
        
        private IInventorySlot AddRandomPeppersIntoRandomSlot(List<IInventorySlot> slots)
        {
            int randomSlotIndex = Random.Range(0, slots.Count);
            IInventorySlot randomSlot = slots[randomSlotIndex];
            int randomCount = Random.Range(1, 4);
            Pepper pepper = new Pepper(_pepperInfo);
            pepper.State.Amount = randomCount;
            Inventory.TryToAddToSlot(this, randomSlot, pepper);
            return randomSlot;
        }

        private void SetUpInventoryUI(InventoryWithSlots inventory)
        {
            var allSlots = Inventory.GetAllSlots();
            var allSlotsCount = allSlots.Length;

            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        private void OnInventoryStateChanged(object sender)
        {
            foreach (UIInventorySlot uiSlot in _uiSlots)
            {
                uiSlot.Refresh();
            }
        }
    }
}