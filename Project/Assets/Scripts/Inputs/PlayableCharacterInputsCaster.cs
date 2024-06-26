using System;
using ReusedCode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayableCharacterInputsCaster : InputMapCaster
{
    public static Action OnInventoryEvent;
    public Action<Vector2> OnMovementChangedEvent;
    public Action OnInteractEvent;

    private InputAction _movement;
    private InputAction _interact;

    private const string MOVEMENT = "Movement";
    private const string INTERACT = "Interact";
    private const string INVENTORY = "Inventory";

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        SubscribeToActions();
    }

    private void OnEnable()
    {
        if (playerInput == null)
        {
            return;
        }
        SubscribeToActions();
    }

    private void SubscribeToActions()
    {
        SubscribeToAction(MOVEMENT, InputActionPhase.Started, OnMovementChanged);
        SubscribeToAction(MOVEMENT, InputActionPhase.Canceled, OnMovementChanged);
        SubscribeToAction(MOVEMENT, InputActionPhase.Performed, OnMovementChanged);

        SubscribeToAction(INTERACT, InputActionPhase.Performed, OnInteractPerformed);
        SubscribeToAction(INVENTORY, InputActionPhase.Performed, OnInventoryPerformed);
    }

    private void OnDisable()
    {
        if (playerInput == null)
        {
            return;
        }
        UnsubscribeToAction(MOVEMENT, InputActionPhase.Started, OnMovementChanged);
        UnsubscribeToAction(MOVEMENT, InputActionPhase.Canceled, OnMovementChanged);
        UnsubscribeToAction(MOVEMENT, InputActionPhase.Performed, OnMovementChanged);

        UnsubscribeToAction(INTERACT, InputActionPhase.Performed, OnInteractPerformed);
        UnsubscribeToAction(INVENTORY, InputActionPhase.Performed, OnInventoryPerformed);
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        OnMovementChangedEvent?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        OnInteractEvent?.Invoke();
    }

    private void OnInventoryPerformed(InputAction.CallbackContext context)
    {
        OnInventoryEvent?.Invoke();
    }
}
