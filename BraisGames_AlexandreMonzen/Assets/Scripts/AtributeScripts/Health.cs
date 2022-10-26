using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _health;
    protected int _actualHealth;
    
    public event Action OnDie;

    protected virtual void Awake()
    {
        _actualHealth = _health;
    }

    public void TakeDamage(int damageToTake)
    {
        _actualHealth -= damageToTake;

        if(_actualHealth <= 0)
        {
            OnDie?.Invoke();
        }
    }

    public void RestoureTotalHealth()
    {
        _actualHealth = _health;
    }
}
