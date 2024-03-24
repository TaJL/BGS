using System;
using ReusedCode;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : InputMapCaster
{
    public static Action<bool> OnVisibilityChangedEvent;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _shopMenu;
    [SerializeField] private ItemUI _item;
    private const string RETURN = "Return";

    private void OnEnable()
    {
        PlayableCharacterInputsCaster.OnInventoryEvent += ShowPersonalInventory;
        Shop.OnStartShoppingEvent += ShowShop;
        SubscribeToAction(RETURN, InputActionPhase.Started, Hide);
    }

    private void OnDisable()
    {
        PlayableCharacterInputsCaster.OnInventoryEvent -= ShowPersonalInventory;
        Shop.OnStartShoppingEvent -= ShowShop;
        UnsubscribeToAction(RETURN, InputActionPhase.Started, Hide);
    }

    private void ShowPersonalInventory()
    {
        Show(false);
    }

    private void ShowShop(Shop shop)
    {
        Show(true);
    }
    
    private void Show(bool isShop)
    {
        _shopMenu?.SetActive(isShop);
        _item.SetAction(isShop);
        Show();
    }

    private void Show()
    {
        _container?.SetActive(true);
        OnVisibilityChangedEvent?.Invoke(true);
    }

    private void Hide(InputAction.CallbackContext context)
    {
        Hide();
    }

    public void Hide()
    {
        _container?.SetActive(false);
        OnVisibilityChangedEvent?.Invoke(false);
    }
}
