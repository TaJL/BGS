using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static Action<bool> OnVisibilityChangedEvent;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _shopMenu;
    [SerializeField] private ItemUI _item;

    private void OnEnable()
    {
        PlayableCharacterInputsCaster.OnInventoryEvent += ShowPersonalInventory;
        Shop.OnStartShoppingEvent += ShowShop;
    }

    private void OnDisable()
    {
        PlayableCharacterInputsCaster.OnInventoryEvent -= ShowPersonalInventory;
        Shop.OnStartShoppingEvent -= ShowShop;
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

    public void Hide()
    {
        _container?.SetActive(false);
        OnVisibilityChangedEvent?.Invoke(false);
    }
}
