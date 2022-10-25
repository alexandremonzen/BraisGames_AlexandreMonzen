using UnityEngine;
using PlayerCharacter;

public abstract class InteractiveObjectPlayer : InteractiveObject, IInteractable
{
    protected PlayerMovement _actualPlayerMovement;
    protected PlayerInteraction _actualPlayerInteraction;
    protected PlayerAnimation _actualPlayerAnimation;

    protected override void Awake()
    {
        base.Awake();
    }

    public virtual void Interact(PlayerInteraction playerInteraction)
    {
        Debug.LogWarning("Função da Interface ''IInteractable'' não foi especificada no item!");
    }
}