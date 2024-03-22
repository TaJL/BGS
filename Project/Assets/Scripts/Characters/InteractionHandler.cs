using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private PlayableCharacterInputsCaster _inputCaster;
    [SerializeField] private List<IInteractable> _interactables;

    private void Awake()
    {
        _interactables = new List<IInteractable>();
        if (_inputCaster == null)
        {
            _inputCaster = GetComponentInParent<PlayableCharacterInputsCaster>();
        }
    }

    private void OnEnable()
    {
        _inputCaster.OnInteractEvent += Interact;
    }

    private void OnDisable()
    {
        _inputCaster.OnInteractEvent -= Interact;
    }

    private void Interact()
    {
        for (int i = _interactables.Count - 1; i >= 0; i--)
        {
            if (_interactables[i] == null ||
                _interactables[i].CanBeInteractedWith() == false)
            {
                continue;
            }
            _interactables[i].Interact();
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable == null)
        {
            return;
        }
        _interactables.Add(interactable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable == null ||
            _interactables.Contains(interactable) == false)
        {
            return;
        }
        _interactables.Remove(interactable);
    }
}
