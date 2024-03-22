using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Dictionary<Item, int> _items;

    private void Awake()
    {
        _items = new Dictionary<Item, int>();
    }

    public void AddItem(Item item, int amount = 1)
    {
        if (ContainsItem(item) == false)
        {
            _items.Add(item, 0);
        }
        _items[item] += amount;
    }

    public void RemoveItem(Item item, int amount = 1)
    {
        if (ContainsItem(item) == false)
        {
            return;
        }
        _items[item] -= amount;
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