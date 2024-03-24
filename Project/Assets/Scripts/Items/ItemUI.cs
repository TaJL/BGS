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
    private int _price;
    private bool _canSell;
    private const float SELLER_OVERPRICE_PERCENTAGE = 1.2f; //TODO: this should be editable later

    private enum EitemAction
    {
        NONE = 0,
        BUY = 1,
        SELL = 2,
        EQUIP = 3,
    }

    private void OnEnable()
    {
        ShopItemUI.OnSelectedEvent += SetShopItem;
        InventoryItemUI.OnSelectedEvent += SetOwnedItem;
        Inventory.OnItemUpdate += CheckForSellPermition;

        SetItem(null);
    }

    private void OnDisable()
    {
        ShopItemUI.OnSelectedEvent -= SetShopItem;
        InventoryItemUI.OnSelectedEvent -= SetOwnedItem;
        Inventory.OnItemUpdate -= CheckForSellPermition;
    }

    private void CheckForSellPermition(Item item, int amount)
    {
        if (_item == item &&
            _action == EitemAction.SELL &&
            amount <= 0)
        {
            _canSell = false;
            UpdateInteractivity();
        }
    }

    private void SetShopItem(Item item)
    {
        _action = EitemAction.BUY;
        _price = Mathf.RoundToInt(item.FairPrice * SELLER_OVERPRICE_PERCENTAGE);
        SetItem(item);
    }

    private void SetOwnedItem(Item item)
    {
        _action = EitemAction.SELL;
        _price = item.FairPrice;
        _canSell = true;
        SetItem(item);
    }

    private void SetItem(Item item)
    {
        _item = item;
        if (item == null)
        {
            _icon.enabled = false;
            _name.text = "";
            _flavor.text = "";
            _button.interactable = false;
            _buttonText.text = "";
            return;
        }
        _name.text = item.Name;
        if (_icon.enabled == false)
        {
            _icon.enabled = true;
        }
        _icon.sprite = item.Icon;
        _flavor.text = $"Price: ${_price}\n{item.FlavorText}";

        UpdateInteractivity();
    }

    public void SetAction(bool isShop)
    {
        _action = isShop ? EitemAction.BUY : EitemAction.EQUIP;
    }

    public void OnConfirmAction()
    {
        switch (_action)
        {
            case EitemAction.BUY:
            {
                CurrencyManager.Instance.Modify(-Mathf.RoundToInt(_item.FairPrice * SELLER_OVERPRICE_PERCENTAGE));
                OnBuyItemEvent?.Invoke(_item);
                UpdateInteractivity();
                break;
            }
            case EitemAction.EQUIP:
            {
                OnEquipItemEvent?.Invoke(_item);
                break;
            }
            case EitemAction.SELL:
            {
                CurrencyManager.Instance.Modify(_item.FairPrice);
                OnSellItemEvent?.Invoke(_item);
                UpdateInteractivity();
                break;
            }
        }
    }

    private void UpdateInteractivity()
    {
        bool canInteract = false;
        string buttonText = "";
        switch (_action)
        {
            case EitemAction.BUY:
            {
                canInteract = CurrencyManager.Instance.CanBuy(Mathf.RoundToInt(_item.FairPrice * SELLER_OVERPRICE_PERCENTAGE));
                buttonText = "Buy";
                break;
            }
            case EitemAction.EQUIP:
            {
                canInteract = _item.CanBeEquipped();
                buttonText = "Equip";
                break;
            }
            case EitemAction.SELL:
            {
                canInteract = _canSell;
                buttonText = "Sell";
                break;
            }
        }
        _button.interactable = canInteract;
        _buttonText.text = canInteract ? buttonText : "";
    }
}