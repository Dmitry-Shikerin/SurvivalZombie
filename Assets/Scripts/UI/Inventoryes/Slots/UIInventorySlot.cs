using System;
using System.Collections;
using System.Collections.Generic;
using Inventories.Abstract;
using UI.Inventoryes.Inventory;
using UI.Inventorys.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
    [SerializeField] private UIInventoryItem _uiInventoryItem;
    
    private UIInventorySecond _uiInventory;
    
    public IInventorySlot Slot { get; private set; }

    private void Awake()
    {
        _uiInventory = GetComponentInParent<UIInventorySecond>() 
                       ?? throw new NullReferenceException(nameof(UIInventory));
    }

    public void SetSlot(IInventorySlot newSlot)
    {
        Slot = newSlot;
    }
    
    public override void OnDrop(PointerEventData eventData)
    {
        UIInventoryItem otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        UIInventorySlot otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
        var otherSlot = otherSlotUI.Slot;
        var inventory = _uiInventory.Inventory;
        
        inventory.TransitFromSlotToSlot(this, otherSlot, Slot);
        
        Refresh();
        otherSlotUI.Refresh();
    }

    public void Refresh()
    {
        if(Slot != null)
            _uiInventoryItem.Refresh(Slot);
    }
}
