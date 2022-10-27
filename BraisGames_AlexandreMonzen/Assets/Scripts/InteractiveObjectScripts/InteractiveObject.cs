using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class InteractiveObject : MonoBehaviour
{
    protected Rigidbody RigidBody;
    protected bool Interacted;
    protected bool CanBeInteracted = true;

    protected virtual void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
        Interacted = false;
        CanBeInteracted = true;
    }
}