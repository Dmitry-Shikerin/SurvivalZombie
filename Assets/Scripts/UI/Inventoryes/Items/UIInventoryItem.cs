using System.Collections;
using System.Collections.Generic;
using Inventories.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private Text _textAmount;

    public IInventoryItem Item { get; private set; }
    
    public void Refresh(IInventorySlot slot)
    {
        if (slot.IsEmpty)
        {
            Cleanup();
            return;
        }

        Item = slot.Item;
        _imageIcon.sprite = Item.Info.SpriteIcon;
        _imageIcon.gameObject.SetActive(true);

        var textAmountEnabled = slot.Amount > 1;
        _textAmount.gameObject.SetActive(textAmountEnabled);

        if (textAmountEnabled)
            _textAmount.text = slot.Amount.ToString();
    }

    private void Cleanup()
    {
        _textAmount.gameObject.SetActive(false);
        _imageIcon.gameObject.SetActive(false);
    }
}
