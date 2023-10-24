using System;
using System.Collections;
using System.Collections.Generic;
using Interactions;
using Inventories;
using Inventories.Abstract;
using Inventories.Items;
using UnityEngine;

public class InteractionWoodpie : MonoBehaviour, IInteractible, ITakeble
{
    [SerializeField] private InventoryItemInfo _info;

    private WoodPie _woodPie;
    
    public Sprite UISprite { get; private set; }
    
    void Start()
    {
        _woodPie = new WoodPie(_info);
        UISprite = _woodPie.Info.SpriteIcon;
        _woodPie.State.Amount = 2;
    }

    public void Interact()
    {
        gameObject.SetActive(false);
    }

    public string GetDescription()
    {
        return "Взять древесину?";
    }

    public IInventoryItem GetItem()
    {
        return _woodPie;
    }
}
