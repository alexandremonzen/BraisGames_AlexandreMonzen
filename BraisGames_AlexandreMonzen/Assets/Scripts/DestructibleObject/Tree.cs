using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDestructible
{
    private HealthStructure _healthStructure;

    private void Awake()
    {
        _healthStructure = GetComponent<HealthStructure>();
    }

    private void Start()
    {
        _healthStructure.OnDie += DestroyObject;
    }

    public void DestroyObject()
    {
        this.gameObject.SetActive(false);
    }
}
