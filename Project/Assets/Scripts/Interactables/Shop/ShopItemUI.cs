using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public static Action<Item> OnSelectedEvent;

    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _button;
    private Item _item;

    private const float SELLER_OVERPRICE_PERCENTAGE = 1.2f; 

    public void SetItem(Item item)
    {
        if (item == null)
        {
            Clear();
            return;
        }
        _icon.enabled = true;
        _icon.sprite = item.Icon;
        _name.text = item.Name;
        _price.text = $"Price: ${Mathf.RoundToInt(item.FairPrice * SELLER_OVERPRICE_PERCENTAGE)}";
        _button.interactable = true;
        _item = item;
    }

    private void Clear()
    {
        _icon.enabled = false;
        _name.text = "";
        _price.text = "";
        _button.interactable = false;
        _item = null;
    }

    public void OnSelected()
    {
        OnSelectedEvent?.Invoke(_item);
    }
}
