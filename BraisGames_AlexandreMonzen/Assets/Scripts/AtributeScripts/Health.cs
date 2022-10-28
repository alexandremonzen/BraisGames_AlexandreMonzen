using System;
using UnityEngine;
using FMODUnity;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _health;
    protected int _actualHealth;

    [Header("Audio FMOD")]
    [SerializeField] private EventReference _hitObjectReference;
    [SerializeField] private EventReference _destroyReference;
    private PlayAudioFMOD _playAudioFMOD;

    public event Action OnHit;
    public event Action OnDie;

    protected virtual void Awake()
    {
        _actualHealth = _health;
        _playAudioFMOD = GetComponent<PlayAudioFMOD>();
    }

    public void TakeDamage(int damageToTake)
    {
        _actualHealth -= damageToTake;
        _playAudioFMOD.PlaySound3D(_hitObjectReference, this.transform.position);

        if (_actualHealth <= 0)
        {
            OnDie?.Invoke();
            _playAudioFMOD.PlaySound3D(_destroyReference, this.transform.position);
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    public void RestoureTotalHealth()
    {
        _actualHealth = _health;
    }
}
