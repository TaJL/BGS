using System;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    public static Action<Shop> OnStartShoppingEvent;

    public Item[] Stock => _stock;

    [SerializeField] private Item[] _stock;

    private void Awake()
    {
        _stock ??= new Item[0];    
    }

    public bool CanBeInteractedWith()
    {
        return true;
    }

    public void Interact(InteractionHandler interactionHandler)
    {
        OnStartShoppingEvent?.Invoke(this);
    }
}
