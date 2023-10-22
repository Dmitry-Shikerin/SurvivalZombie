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
    [SerializeField] private Sprite _uiSprite;
    [SerializeField] private InventoryItemInfo _info;

    private WoodPie _woodPie;
    
    public Sprite UISprite => _uiSprite;
    
    void Start()
    {
        _woodPie = new WoodPie(_info);
        _woodPie.State.Amount = 2;
    }

    void Update()
    {
        
    }
    
    public void Interact()
    {
        Debug.Log("поднял деревяшки");
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
