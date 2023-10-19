using System;
using Inventories.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Inventories
{
    public class InventoryTester : MonoBehaviour
    {
        private IInventory _inventory;

        private void Awake()
        {
            int inventoryCapacity = 10;
            _inventory = new InventoryWithSlots(inventoryCapacity);
            Debug.Log($"Инвентарь сосдан, размер: {inventoryCapacity}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
                AddRandomApples();

            if (Input.GetKeyDown(KeyCode.C))
                RemoveRandomApples();
        }
        
        private void AddRandomApples()
        {
            int randomCount = Random.Range(1, 5);
            // var apple = new Apple(5);
            // apple.State.Amount = randomCount;
            // _inventory.TryToAdd(this, apple);
        }

        private void RemoveRandomApples()
        {
            int randomCount = Random.Range(1, 10);
            _inventory.Remove(this, typeof(Apple), randomCount);
        }
    }
}