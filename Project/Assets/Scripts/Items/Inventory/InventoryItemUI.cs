using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountLabel;
    [SerializeField] private Button _button;

    public void SetItem(Item item, int amount)
    {
        if (item == null ||
            amount <= 0)
        {
            Clear();
        }
        _icon.enabled = true;
        _icon.sprite = item.Icon;
        _amountLabel.text = amount.ToString();
        _button.interactable = true;
    }

    private void Clear()
    {
        _icon.enabled = false;
        _amountLabel.text = "";
        _button.interactable = false;
    }
}