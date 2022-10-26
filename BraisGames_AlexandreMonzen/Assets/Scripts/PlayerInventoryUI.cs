using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerCharacter;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Text _woodAmountText;
    [SerializeField] private Text _stoneAmountText;
    [SerializeField] private Text _leafAmountText;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _playerInventory.UpdateUI += UpdateUI;
        UpdateUI();
    }

    private void OnDisable()
    {
        _playerInventory.UpdateUI -= UpdateUI;
    }

    public void UpdateUI()
    {
        _woodAmountText.text = _playerInventory.Inventory[ItemID.Wood].ToString();
        _stoneAmountText.text = _playerInventory.Inventory[ItemID.Stone].ToString();
        _leafAmountText.text = _playerInventory.Inventory[ItemID.Leaf].ToString();
    }
}
