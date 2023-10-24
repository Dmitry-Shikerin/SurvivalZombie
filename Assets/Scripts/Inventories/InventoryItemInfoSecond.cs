using Inventories.Abstract;
using UnityEngine;

namespace Inventories
{
    public class InventoryItemInfoSecond : IInventoryItemInfo

    {
        public InventoryItemInfoSecond
            (string id,
            string title,
            string description,
            int maxItemsInInventorySlot,
            Sprite spriteIcon)
        {
            ID = id;
            Title = title;
            Description = description;
            MaxItemsInInventorySlot = maxItemsInInventorySlot;
            SpriteIcon = spriteIcon;
        }

        public string ID { get; }
        public string Title { get; }
        public string Description { get; }
        public int MaxItemsInInventorySlot { get; }
        public Sprite SpriteIcon { get; }
    }
}