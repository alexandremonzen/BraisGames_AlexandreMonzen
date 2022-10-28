using UnityEngine;

public sealed class HealthStructure : Health
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        if (_animator)
        {
            OnHit += PlayHitAnimation;
        }
    }

    private void OnDisable()
    {
        if (_animator)
        {
            OnHit -= PlayHitAnimation;
        }
    }

    private void PlayHitAnimation()
    {
        if (_animator)
        {
            _animator.SetTrigger("onHit");
        }
    }
}
