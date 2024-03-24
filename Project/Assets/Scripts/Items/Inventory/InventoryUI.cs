using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryItemUI[] _items;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void OnEnable()
    {
        UpdateVisual();
        ItemUI.OnBuyItemEvent += UpdateVisual;
        ItemUI.OnSellItemEvent += UpdateVisual;
    }

    private void OnDisable()
    {
        ItemUI.OnBuyItemEvent -= UpdateVisual;
        ItemUI.OnSellItemEvent -= UpdateVisual;
    }

    private void UpdateVisual(Item item)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        int i = 0;
        foreach (KeyValuePair<Item, int> item in _inventory.Items)
        {
            _items[i].SetItem(item.Key, item.Value);
            i++;
        }

        for (int j = i; j < _items.Length; j++)
        {
            _items[j].SetItem(null, 0);
        }
    }
}