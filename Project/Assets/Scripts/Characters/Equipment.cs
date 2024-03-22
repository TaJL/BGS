using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Equipment : SerializedMonoBehaviour
{
    [HideInInspector] public Action<Item, Item> OnEquipmentChangedEvent;

    [SerializeField] private Dictionary<EItemSlot, Item> _equippedItems;

    private void Awake()
    {
        _equippedItems ??= new Dictionary<EItemSlot, Item>();
    }

    [Button]
    private void Equip(Item item)
    {
        if (item.CanBeEquipped == false ||
            item.Slot == EItemSlot.NONE ||
            item == GetEquippedItemInSlot(item.Slot))
        {
            return;
        }

        if (_equippedItems.ContainsKey(item.Slot) == false)
        {
            _equippedItems.Add(item.Slot, null);
        }
        
        Item previousItem = _equippedItems[item.Slot];
        _equippedItems[item.Slot] = item;
        OnEquipmentChangedEvent?.Invoke(item, previousItem);
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
