using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;

public class InteractionTree : MonoBehaviour, IInteractible
{
    [SerializeField] private Sprite _uiSprite;
    [SerializeField] private GameObject _tree;
    [SerializeField] private GameObject _stump;
    [SerializeField] private GameObject _woodPie;
    
    public Sprite UISprite => _uiSprite;

    private int _currentNumberAxeBlows;
    private int _maxNumberAxeBlows;
    
    void Start()
    {
        _currentNumberAxeBlows = 0;
        _maxNumberAxeBlows = 4;
        
        _woodPie.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    
    public void Interact()
    {
        if (_currentNumberAxeBlows <= _maxNumberAxeBlows)
        {
            _currentNumberAxeBlows++;
        }
        else
        {
            _currentNumberAxeBlows = 0;
            _stump.gameObject.SetActive(true);
            _woodPie.gameObject.SetActive(true);
            _tree.gameObject.SetActive(false);
        }
    }

    public string GetDescription()
    {
        if (_tree.gameObject.activeSelf == false)
            return null;
        
        return "Срубить дерево?";
    }
}
