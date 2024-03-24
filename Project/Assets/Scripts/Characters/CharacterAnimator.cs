using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterAnimator : SerializedMonoBehaviour
{
    [SerializeField] private Equipment _equipment;
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterSlotAnimator _baseBody;
    [SerializeField] private Dictionary<EItemSlot, CharacterSlotAnimator> _slots;

    private void Awake()
    {
        if (_equipment == null)
        {
            _equipment = GetComponent<Equipment>();
        }
        if (_movement == null)
        {
            _movement = GetComponent<CharacterMovement>();
        }
        if (_baseBody == null)
        {
            _baseBody = GetComponent<CharacterSlotAnimator>();
        }
        _slots ??= new Dictionary<EItemSlot, CharacterSlotAnimator>();
        foreach (CharacterSlotAnimator slot in _slots.Values)
        {
            slot?.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _movement.OnIsWalkingEvent += UpdateAnimation;
        _equipment.OnEquipmentChangedEvent += UpdateSlot;
    }

    private void OnDisable()
    {
        _movement.OnIsWalkingEvent -= UpdateAnimation;
        _equipment.OnEquipmentChangedEvent -= UpdateSlot;
    }

    private void UpdateAnimation(bool isWalking)
    {
        _baseBody.SetWalkingParameter(isWalking);
        foreach (CharacterSlotAnimator slotAnimator in _slots.Values)
        {
            if (slotAnimator == null)
            {
                continue;
            }
            slotAnimator.SetWalkingParameter(isWalking);
        }
    }

    private void UpdateSlot(EItemSlot slot, Item newItem)
    {
        if (_slots.ContainsKey(slot) == false ||
            _slots[slot] == null)
        {
            return;
        }
        _slots[slot].SetActive(newItem != null);
        if (newItem != null)
        {
            _slots[slot].SetSpriteLibraryAsset(newItem.LibraryAsset);
        }
    }
}