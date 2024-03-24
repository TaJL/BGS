using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryItemUI : MonoBehaviour
{
    public static Action<Item> OnSelectedEvent;

    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountLabel;
    [SerializeField] private Button _button;
    private Item _item;

    public void SetItem(Item item, int amount)
    {
        if (item == null ||
            amount <= 0)
        {
            Clear();
            return;
        }
        _icon.enabled = true;
        _icon.sprite = item.Icon;
        _amountLabel.text = amount.ToString();
        _button.interactable = true;
        _item = item;
    }

    private void Clear()
    {
        _icon.enabled = false;
        _amountLabel.text = "";
        _button.interactable = false;
        _item = null;
    }

    public void OnSelected()
    {
        OnSelectedEvent?.Invoke(_item);
    }
}