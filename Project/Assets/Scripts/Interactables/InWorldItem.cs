using Sirenix.OdinInspector;
using UnityEngine;

public class InWorldItem : MonoBehaviour, IInteractable
{
    [SerializeField, OnValueChanged(nameof(UpdateSprite))] private Item _item;
    [SerializeField] private SpriteRenderer _renderer;

    private void UpdateSprite()
    {
        if (_item != null &&
            _renderer != null)
        {
            _renderer.sprite = _item.Icon;
        }
    }

    public bool CanBeInteractedWith()
    {
        return true;
    }

    public void Interact(InteractionHandler handler)
    {
        if (handler == null ||
            handler.transform.parent.TryGetComponent<Inventory>(out Inventory inventory) == false)
        {
            return;
        }
        inventory.AddItem(_item);
        Destroy(gameObject);
    }
}