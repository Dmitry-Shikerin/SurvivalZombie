
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
    public interface IInteractible
    {
        Sprite UISprite { get; }
        
        void Interact();
        string GetDescription();
    }
}