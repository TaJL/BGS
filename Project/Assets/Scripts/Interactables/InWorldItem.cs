using UnityEngine;

public class InWorldItem : MonoBehaviour, IInteractable
{
    [SerializeField] private Item _item;

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