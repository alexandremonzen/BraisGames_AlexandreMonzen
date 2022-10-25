using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerCharacter;
//using FMODUnity;
//using FMOD.Studio;

public class CarryObject : DynamicInteractiveObjectPlayer
{
    protected bool _isBeingCarried;
    protected BoxCollider _triggerBoxCollider;

    protected override void Awake()
    {
        base.Awake();
        _isBeingCarried = false;
        _triggerBoxCollider = GetComponent<BoxCollider>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (_isBeingCarried)
        {
            if (_actualPlayerInteraction)
            {
                transform.position = _actualPlayerInteraction.CarryOffset.position;
                transform.LookAt(new Vector3(_actualPlayerInteraction.PlayerMovement.transform.position.x, transform.position.y, _actualPlayerInteraction.PlayerMovement.transform.position.z));
            }
        }
    }

    public override void Interact(PlayerInteraction playerInteraction)
    {
        if (!Interacted)
        {
            StartCarryAction(playerInteraction);
        }
        else
        {
            StopCarryAction(playerInteraction);
        }
    }

    private void RotateToNormalRotation()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    protected virtual void StartCarryAction(PlayerInteraction playerInteraction)
    {
        RotateToNormalRotation();
        playerInteraction.CanInteract = false;
        playerInteraction.PlayerAnimation.animator.SetLayerWeight(1, 1);

        //used to drag the item in the update, fixed update and late update
        _actualPlayerInteraction = playerInteraction;

        RigidBody.isKinematic = true;
        RigidBody.useGravity = false;
        _isBeingCarried = true;

        _physicsColliderGameObject.layer = _beingUsedLayer;

        Interacted = true;
    }

    protected virtual void StopCarryAction(PlayerInteraction playerInteraction)
    {
        playerInteraction.CanInteract = true;
        playerInteraction.PlayerAnimation.animator.SetLayerWeight(1, 0);

        //setting null _actualPlayer variables case it needs to check in updates
        _actualPlayerInteraction = null;

        _triggerBoxCollider.enabled = true;
        RigidBody.isKinematic = false;
        RigidBody.useGravity = true;
        _isBeingCarried = false;

        _physicsColliderGameObject.layer = _normalLayer;

        Interacted = false;
    }
}