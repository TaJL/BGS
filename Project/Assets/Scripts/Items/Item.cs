using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public string Name => _name;
    public string FlavorText => _flavorText;
    public int FairPrice => _fairPrice;
    public Sprite Icon => _icon;
    public bool CanBeEquipped => _canBeEquipped;
    public EItemSlot Slot => _slot;

    [SerializeField] private string _name;
    [SerializeField] private string _flavorText;
    [SerializeField] private int _fairPrice;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _canBeEquipped;
    [SerializeField] private EItemSlot _slot;
}