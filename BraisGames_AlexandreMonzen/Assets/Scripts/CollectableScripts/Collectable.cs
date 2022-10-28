using System.Collections;
using UnityEngine;
using PlayerCharacter;
using FMODUnity;

public sealed class Collectable : MonoBehaviour
{
    [SerializeField] private ItemID _itemID;
    [SerializeField] private int _amount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeToDeactivate = 10;
    private bool _wasCollected;

    private Rigidbody _rigidbody;
    private Collider _physicsCollider;
    private Collider _triggerCollider;
    private PlayerInventory _actualPlayerInventory;

    [Header("Audio FMOD")]
    [SerializeField] private EventReference _pickUpReference;
    private PlayAudioFMOD _playAudioFMOD;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _physicsCollider = transform.GetChild(0).GetComponent<Collider>();
        _triggerCollider = GetComponent<Collider>();
        _playAudioFMOD = GetComponent<PlayAudioFMOD>();

        _wasCollected = false;
        _triggerCollider.enabled = false;
    }

    private void OnEnable()
    {
        Invoke("EnableTriggerCollider", 1);
        StartCoroutine(DeactivateAfterTime());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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

        _playAudioFMOD.PlaySound3D(_pickUpReference, this.transform.position);

        yield return null;
    }

    private void EnableTriggerCollider()
    {
        _triggerCollider.enabled = true;
    }

    private IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(_timeToDeactivate);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
