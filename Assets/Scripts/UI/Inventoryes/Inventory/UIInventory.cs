using Inventories;
using UnityEngine;

namespace UI.Inventorys.Inventory
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private InventoryItemInfo _appleInfo;
        [SerializeField] private InventoryItemInfo _pepperInfo;
        
        private UIInventoryTester _tester;

        public InventoryWithSlots Inventory => _tester.Inventory;

        private void Start()
        {
            var uiSlots = GetComponentsInChildren<UIInventorySlot>();
            _tester = new UIInventoryTester(_appleInfo, _pepperInfo, uiSlots);
            _tester.FillSlots();
        }
    }
}