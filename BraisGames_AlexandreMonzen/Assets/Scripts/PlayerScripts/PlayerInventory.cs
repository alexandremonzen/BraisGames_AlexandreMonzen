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

        public void ChangeItemAmountOnInventory(ItemID key, int amount)
        {
            int value;
            if (inventory.TryGetValue(key, out value))
            {
                inventory[key] = value + amount;

                if (value < 0)
                {
                    value = 0;
                }

                UpdateUI?.Invoke();
            }
        }

        public bool CompareAmountOnInventory(ItemID key, int amount)
        {
            int value;
            if (inventory.TryGetValue(key, out value))
            {
                if (value >= amount)
                {
                    Debug.Log(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void InvokeUpdateUIAction()
        {
            UpdateUI?.Invoke();
        }
    }
}