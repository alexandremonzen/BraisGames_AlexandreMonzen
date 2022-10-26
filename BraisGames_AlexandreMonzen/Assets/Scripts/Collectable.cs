using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerCharacter;

public sealed class Collectable : MonoBehaviour
{
    [SerializeField] private ItemID _itemID;
    [SerializeField] private int _amount;
    [SerializeField] private float _moveSpeed;
    private bool _wasCollected;
    
    private Rigidbody _rigidbody;
    private Collider _physicsCollider;
    private Collider _triggerCollider;
    private PlayerInventory _actualPlayerInventory;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _physicsCollider = transform.GetChild(0).GetComponent<Collider>();
        _triggerCollider = GetComponent<Collider>();
        
        _wasCollected = false;
        _triggerCollider.enabled = false;
    }

    private void OnEnable()
    {
        Invoke("EnableTriggerCollider", 1);
    }

    private void OnTriggerEnter(Collider col)
    {
        PlayerInventory playerInventory = col.GetComponent<PlayerInventory>();
        if (playerInventory)
        {
            if (!_wasCollected)
            {
                _actualPlayerInventory = playerInventory;
                StartCoroutine(BeCollected());
            }
        }
    }

    private IEnumerator BeCollected()
    {
        _rigidbody.useGravity = false;
        _wasCollected = true;
        _physicsCollider.enabled = false;

        while (Vector3.Distance(this.transform.position, _actualPlayerInventory.transform.position) > 0.25f && _actualPlayerInventory)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _actualPlayerInventory.transform.position, _moveSpeed * Time.deltaTime);
            yield return null;
        }

        _actualPlayerInventory.ChangeItemAmountOnInventory(_itemID, _amount);
        _actualPlayerInventory = null;

        this.gameObject.SetActive(false);
        _wasCollected = false;
        _physicsCollider.enabled = true;
        _rigidbody.useGravity = true;

        yield return null;
    }

    private void EnableTriggerCollider()
    {
        _triggerCollider.enabled = true;
    }
}
