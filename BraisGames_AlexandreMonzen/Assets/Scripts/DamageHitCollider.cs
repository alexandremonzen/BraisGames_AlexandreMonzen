using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitCollider : MonoBehaviour
{
    [SerializeField] private int _damageValue;
    [SerializeField] private bool _canDamageObjects;
    [SerializeField] private bool _canDamageCreatures;

    private Collider _hitCollider;

    private void Awake()
    {
        _hitCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (_canDamageObjects && _canDamageCreatures)
        {
            Health health = col.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(_damageValue);
                _hitCollider.enabled = false;
            }
            return;
        }

        if (_canDamageCreatures)
        {
            HealthLife healthLife = col.GetComponent<HealthLife>();
            if (healthLife)
            {
                healthLife.TakeDamage(_damageValue);
                _hitCollider.enabled = false;
                Debug.Log("Rodou aqui");
            }
        }

        if (_canDamageObjects)
        {
            HealthStructure healthStructure = col.GetComponent<HealthStructure>();
            if (healthStructure)
            {
                healthStructure.TakeDamage(_damageValue);
                _hitCollider.enabled = false;
                Debug.Log("Rodou aqui");
            }
        }


    }
}
