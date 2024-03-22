using System;
using UnityEngine;

public class PersonalInventory : MonoBehaviour
{
    public static Action<bool> OnVisibilityChangedEvent;

    [SerializeField] private GameObject _inventoryMenu;

    private void OnEnable()
    {
        PlayableCharacterInputsCaster.OnInventoryEvent += Show;
    }

    private void OnDisable()
    {
        PlayableCharacterInputsCaster.OnInventoryEvent -= Show;
    }

    private void Show()
    {
        _inventoryMenu?.SetActive(true);
        OnVisibilityChangedEvent?.Invoke(true);
    }

    public void Hide()
    {
        _inventoryMenu?.SetActive(false);
        OnVisibilityChangedEvent?.Invoke(false);
    }
}
