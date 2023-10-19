using UnityEngine;

namespace Inventories.Abstract
{
    public interface IInventoryItemInfo
    {
        string ID { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemsInInventorySlot { get; }
        Sprite SpriteIcon { get; }
    }
}