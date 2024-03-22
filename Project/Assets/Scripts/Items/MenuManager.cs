using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static Action<bool> OnVisibilityChangedEvent;

    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _equipmentMenu;
    [SerializeField] private GameObject _shopMenu;

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
        _shopMenu?.SetActive(false);
        _equipmentMenu?.SetActive(true);
        Show();
    }

    private void ShowShop(Shop shop)
    {
        _shopMenu?.SetActive(true);
        _equipmentMenu?.SetActive(false);
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
