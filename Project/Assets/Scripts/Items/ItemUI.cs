using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ItemUI : MonoBehaviour
{
    public static Action<Item> OnEquipItemEvent;
    public static Action<Item> OnSellItemEvent;
    public static Action<Item> OnBuyItemEvent;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _flavor;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private EitemAction _action;
    private Item _item;

    private enum EitemAction
    {
        NONE = 0,
        BUY = 1,
        SELL = 2,
        EQUIP = 3,
    }

    private void OnEnable()
    {
        InventoryItemUI.OnSelectedEvent += UpdateData;
    }

    private void OnDisable()
    {
        InventoryItemUI.OnSelectedEvent -= UpdateData;
    }

    private void UpdateData(Item item)
    {
        _item = item;
        _name.text = item.Name;
        if (_icon.enabled == false)
        {
            _icon.enabled = true;
        }
        _icon.sprite = item.Icon;
        _flavor.text = $"Price: ${item.FairPrice}\n{item.FlavorText}";
        switch (_action)
        {
            case EitemAction.BUY:
            {
                break;
            }
            case EitemAction.EQUIP:
            {
                bool canBeEquipped = item.CanBeEquipped();
                _button.interactable = canBeEquipped;
                _buttonText.text = canBeEquipped ? "Equip" : "";
                break;
            }
            case EitemAction.SELL:
            {
                break;
            }
        }
    }

    public void SetAction(bool isShop)
    {
        SetAction(isShop ? EitemAction.SELL : EitemAction.EQUIP);
    }

    private void SetAction(EitemAction action)
    {
        _action = action;
        switch (action)
        {
            case EitemAction.NONE:
            {
                _buttonText.text = "";
                break;
            }
            case EitemAction.BUY:
            {
                _buttonText.text = "Buy";
                break;
            }
            case EitemAction.EQUIP:
            {
                _buttonText.text = "Equip";
                break;
            }
            case EitemAction.SELL:
            {
                _buttonText.text = "Sell";
                break;
            }
        }
    }

    public void OnConfirmAction()
    {
        switch (_action)
        {
            case EitemAction.BUY:
            {
                OnBuyItemEvent?.Invoke(_item);
                break;
            }
            case EitemAction.EQUIP:
            {
                OnEquipItemEvent?.Invoke(_item);
                break;
            }
            case EitemAction.SELL:
            {
                OnSellItemEvent?.Invoke(_item);
                break;
            }
        }
    }
}