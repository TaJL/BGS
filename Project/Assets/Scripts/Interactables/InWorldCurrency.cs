using UnityEngine;

public class InWorldCurrency : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;

    public bool CanBeInteractedWith()
    {
        return true;
    }

    public void Interact(InteractionHandler handler)
    {
        CurrencyManager.Instance.Modify(_value);
        Destroy(gameObject);
    }
}