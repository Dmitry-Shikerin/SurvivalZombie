using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class InteractionMetallGate : MonoBehaviour, IInteractible
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private Sprite _uiSprite;
    private Animator _animator;

    public Sprite UISprite => _uiSprite;
    
    void Start()
    {
        _animator = GetComponent<Animator>();

        if (_isOpen)
        {
            _animator.SetBool("isOpen", true);
        }
    }

    void Update()
    {
        
    }


    public void Interact()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            _animator.SetBool("isOpen", true);
        }
        else
        {
            _animator.SetBool("isOpen", false);
        }
    }

    public string GetDescription()
    {
        if (_isOpen)
            return "Нажмите [F] чтобы закрыть дверь";

        return "Нажмите [F] чтобы открыть дверь";
    }
}
