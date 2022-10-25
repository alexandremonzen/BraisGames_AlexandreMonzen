using UnityEngine;
using PlayerCharacter;

public interface IInteractable
{
    public void Interact(PlayerInteraction playerInteraction);
    public GameObject gameObject { get; }
}