using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : SerializedScriptableObject
{
    public string Name => _name;
    public string FlavorText => _flavorText;
    public int FairPrice => _fairPrice;
    public Sprite Icon => _icon;
    public EItemSlot Slot => _slot;
    public SpriteLibraryAsset LibraryAsset => _libraryAsset;

    [SerializeField] private string _name;
    [SerializeField] private string _flavorText;
    [SerializeField] private Sprite _icon;
    
    [SerializeField, BoxGroup("Equipment")]
    private EItemSlot _slot;
    [SerializeField, BoxGroup("Equipment"), ShowIf(nameof(CanBeEquipped))]
    private SpriteLibraryAsset _libraryAsset;
    
    
    [SerializeField, BoxGroup("Pricing")] private int _fairPrice;
    [SerializeField, BoxGroup("Pricing/Seasonal Data")] private ESeason[] _discountSeasons;
    [SerializeField, BoxGroup("Pricing/Seasonal Data"), ShowIf(nameof(HasDiscountSeasons)), Min(0)]
    private int _discountPrice;
    [SerializeField, BoxGroup("Pricing/Seasonal Data")] private ESeason[] _overchargeSeasons;
    [SerializeField, BoxGroup("Pricing/Seasonal Data"), ShowIf(nameof(HasOverchargeSeasons)), Min(0)]
    private int _overchargePrice;

    public bool CanBeEquipped()
    {
        return _slot != EItemSlot.NONE;
    }

    public bool HasDiscountSeasons()
    {
        return  _discountSeasons != null &&
                _discountSeasons.Length > 0;
    }

    public bool HasOverchargeSeasons()
    {
        return  _overchargeSeasons != null &&
                _overchargeSeasons.Length > 0;
    }
}