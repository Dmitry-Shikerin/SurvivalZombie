
using Inventories.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions
{
    public interface IInteractible
    {
        Sprite UISprite { get; }
        
        void Interact();
        // void Interact(out IInventoryItem item);
        string GetDescription();
    }
}