using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Inventory : SerializedMonoBehaviour
{
    public static Action<Item, int> OnItemUpdate;

    public Dictionary<Item, int> Items => _items;

    [SerializeField] private Dictionary<Item, int> _items;
    [SerializeField] private int _maxSize = 16;

    private void Awake()
    {
        _items = new Dictionary<Item, int>();
    }

    private void OnEnable()
    {
        ItemUI.OnBuyItemEvent += AddItem;
        ItemUI.OnSellItemEvent += RemoveItem;
    }

    private void OnDisable()
    {
        ItemUI.OnBuyItemEvent -= AddItem;
        ItemUI.OnSellItemEvent -= RemoveItem;
    }

    public void AddItem(Item item)
    {
        AddItem(item, 1);
    }

    private void AddItem(Item item, int amount)
    {
        if (ContainsItem(item) == false)
        {
            _items.Add(item, 0);
        }
        _items[item] += amount;
        OnItemUpdate?.Invoke(item, _items[item]);
    }

    public bool CanAddItem()
    {
        return  _items == null ||
                _items.Count >= _maxSize;
    }

    private void RemoveItem(Item item)
    {
        RemoveItem(item, 1);
    }

    public void RemoveItem(Item item, int amount)
    {
        if (ContainsItem(item) == false)
        {
            return;
        }
        _items[item] -= amount;
        OnItemUpdate?.Invoke(item, _items[item]);
        if (_items[item] <= 0)
        {
            _items.Remove(item);
        }
    }

    public int GetItemAmount(Item item)
    {
        if (ContainsItem(item) == false)
        {
            return 0;
        }
        return _items[item];
    }

    public bool ContainsItem(Item item)
    {
        return _items.ContainsKey(item);
    }
}