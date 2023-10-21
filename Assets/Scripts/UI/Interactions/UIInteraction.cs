using System;
using System.Collections;
using System.Collections.Generic;
using Interactions;
using Players.PlayerInteractions.Overlap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private PlayerOverlapCollision _playerOverlapCollision;
    
    private void OnEnable()
    {
        _playerOverlapCollision.OnInteractibleChanged += ChangeState;
    }

    private void OnDisable()
    {
        _playerOverlapCollision.OnInteractibleChanged -= ChangeState;
    }

    private void ChangeState(IInteractible interactible)
    {
        if (interactible != null)
        {
            ShowInfo();
            _text.text = interactible.GetDescription();
            _image.sprite = interactible.UISprite;
        }
        else
        {
            HideInfo();
        }
    }
    
    private void ShowInfo()
    {
        _image.gameObject.SetActive(true);
        _text.gameObject.SetActive(true);
    }

    private void HideInfo()
    {
        _image.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }
}
