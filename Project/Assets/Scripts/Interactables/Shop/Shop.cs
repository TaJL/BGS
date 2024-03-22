using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    public static Action<Shop> OnStartShoppingEvent;

    public bool CanBeInteractedWith()
    {
        return true;
    }

    public void Interact(InteractionHandler interactionHandler)
    {
        OnStartShoppingEvent?.Invoke(this);
    }
}
