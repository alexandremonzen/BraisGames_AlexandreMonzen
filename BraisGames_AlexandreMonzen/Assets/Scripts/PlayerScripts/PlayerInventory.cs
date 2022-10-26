using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCharacter
{
    public sealed class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Dictionary<ItemID, int> inventory;

        public Dictionary<ItemID, int> Inventory { get => inventory; }

        public event Action UpdateUI;

        private void Awake()
        {
            inventory = new Dictionary<ItemID, int>();

            inventory.Add(ItemID.Wood, 0);
            inventory.Add(ItemID.Stone, 0);
            inventory.Add(ItemID.Leaf, 0);
        }

        private void Update()
        {

            // ItemID key = ItemID.Stone;
            // int value;
            // inventory.TryGetValue(key, out value);
            // if (value >= 3)
            // {
            //     inventory[key] = 0;
            // }

        }

        public void ChangeItemAmountOnInventory(ItemID key, int amount)
        {
            int value;
            if (inventory.TryGetValue(key, out value))
            {
                inventory[key] = value + amount;
                Debug.Log(inventory[key]);
                UpdateUI?.Invoke();
            }
        }
    }
}