using UnityEngine;

public abstract class DynamicInteractiveObjectPlayer : InteractiveObjectPlayer
{
    [Header("Layer Setup")]
    [SerializeField] protected int _normalLayer;
    [SerializeField] protected int _beingUsedLayer;
    protected GameObject _physicsColliderGameObject;

    [Header("Weight Values")]
    [Tooltip("Higher the value, ligther will be")]
    [SerializeField][Range(1, 500)] protected float _moveMultiplier = 250;

    protected override void Awake()
    {
        base.Awake();
        _physicsColliderGameObject = transform.GetChild(0).gameObject;
    }

    protected virtual void Start()
    {

    }
}