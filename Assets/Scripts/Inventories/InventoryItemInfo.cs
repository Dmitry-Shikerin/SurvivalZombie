using Inventories.Abstract;
using UnityEngine;

namespace Inventories
{
    [CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "GamePlay/Items/Create New Item Info")]
    public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private int _maxItemsInInventorySlot;
        [SerializeField] private Sprite _spriteIcon;

        public string ID => _id;
        public string Title => _title;
        public string Description => _description;
        public int MaxItemsInInventorySlot => _maxItemsInInventorySlot;
        public Sprite SpriteIcon => _spriteIcon;
    }
}