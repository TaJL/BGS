using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopItemUI[] _items;

    private void OnEnable()
    {
        Shop.OnStartShoppingEvent += UpdateVisuals;  
    }

    private void OnDisable()
    {
        Shop.OnStartShoppingEvent -= UpdateVisuals;
    }

    private void UpdateVisuals(Shop shop)
    {
        int i = 0;
        foreach (Item item in shop.Stock)
        {
            _items[i].SetItem(item);
            i++;
        }

        for (int j = i; j < _items.Length; j++)
        {
            _items[j].SetItem(null);
        }
    }
}