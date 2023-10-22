using System;
using System.Collections.Generic;
using Inventories;
using Inventories.Abstract;
using UI.Inventorys.Inventory;
using Unity.VisualScripting;
using UnityEngine;

namespace UI.Inventoryes.Inventory
{
    public class UIInventorySecond : MonoBehaviour
    {
        private Canvas _canvas;
        private UIInventorySlot[] _uiSlots;


        public InventoryWithSlots Inventory { get; private set; }

        public bool IsVisible => _canvas.gameObject.activeSelf;

        
        private void Awake()
        {
            Inventory = new InventoryWithSlots(15);
            Inventory.OnInventoryStateChanged += OnInventoryStateChanged;
            
            _canvas = GetComponentInChildren<Canvas>(true);
            _uiSlots = GetComponentsInChildren<UIInventorySlot>(true);
            FillSlots();
        }

        
        private void Start()
        {
            // Inventory = new InventoryWithSlots(15);
            // Inventory.OnInventoryStateChanged += OnInventoryStateChanged;

            // _canvas = GetComponentInChildren<Canvas>();
            // _uiSlots = GetComponentsInChildren<UIInventorySlot>();
            // FillSlots();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (IsVisible)
                    _canvas.gameObject.SetActive(false);
                else
                    _canvas.gameObject.SetActive(true);
            }
        }

        public void FillSlots()
        {
            // IInventorySlot[] allSlots = Inventory.GetAllSlots();
            // List<IInventorySlot> availableSlots = new List<IInventorySlot>(allSlots);
            SetUpInventoryUI(Inventory);
        }

        private void SetUpInventoryUI(InventoryWithSlots inventory)
        {
            IInventorySlot[] allSlots = Inventory.GetAllSlots();
            int allSlotsCount = allSlots.Length;

            for (int i = 0; i < allSlotsCount; i++)
            {
                IInventorySlot slot = allSlots[i];
                UIInventorySlot uiSlot = _uiSlots[i];
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