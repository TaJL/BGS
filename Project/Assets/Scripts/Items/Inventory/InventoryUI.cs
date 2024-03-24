using System.Collections;
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

    private void UpdateVisual()
    {
        
    }
}