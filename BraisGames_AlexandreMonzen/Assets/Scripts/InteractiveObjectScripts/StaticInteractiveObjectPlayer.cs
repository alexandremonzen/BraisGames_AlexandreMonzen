using UnityEngine;

public abstract class StaticInteractiveObjectPlayer : InteractiveObjectPlayer
{
    protected override void Awake()
    {
        base.Awake();

        RigidBody.isKinematic = true;
        RigidBody.useGravity = false;
        RigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}