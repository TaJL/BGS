using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Equipment : SerializedMonoBehaviour
{
    [HideInInspector] public Action<EItemSlot, Item> OnEquipmentChangedEvent;

    [SerializeField] private Dictionary<EItemSlot, Item> _equippedItems;

    private void Awake()
    {
        _equippedItems ??= new Dictionary<EItemSlot, Item>();
    }

    private void OnEnable()
    {
        ItemUI.OnEquipItemEvent += Equip;
    }

    private void OnDisable()
    {
        ItemUI.OnEquipItemEvent -= Equip;
    }

    private void Equip(Item item)
    {
        if (item == null ||
            item.CanBeEquipped() == false ||
            item.Slot == EItemSlot.NONE ||
            item == GetEquippedItemInSlot(item.Slot))
        {
            return;
        }

        if (_equippedItems.ContainsKey(item.Slot) == false)
        {
            _equippedItems.Add(item.Slot, null);
        }

        UpdateSlot(item.Slot, item);
    }

    private void Remove(EItemSlot slot)
    {
        UpdateSlot(slot, null);
    }

    private void UpdateSlot(EItemSlot slot, Item item)
    {
        if (_equippedItems.ContainsKey(slot) == false)
        {
            return;
        }
        Item previousItem = _equippedItems[slot];
        _equippedItems[slot] = item;
        OnEquipmentChangedEvent?.Invoke(slot, item);
    }

    private Item GetEquippedItemInSlot(EItemSlot slot)
    {
        if (_equippedItems.ContainsKey(slot))
        {
            return _equippedItems[slot];
        }
        return null;
    }
}
