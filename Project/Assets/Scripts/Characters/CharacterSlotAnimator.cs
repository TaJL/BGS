using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(Animator), typeof(SpriteLibrary))]
public class CharacterSlotAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteLibrary _spriteLibrary;
    [SerializeField] private string _walkingAnimationParameter = "IsWalking";
    private bool _isActive = true;

    private void OnEnable()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        if (_spriteLibrary == null)
        {
            _spriteLibrary = GetComponent<SpriteLibrary>();
        }
    }

    public void SetActive(bool isActive)
    {
        if (_isActive == isActive)
        {
            return;
        }
        _isActive = isActive;
        gameObject.SetActive(isActive);
    }

    public void SetSpriteLibraryAsset(SpriteLibraryAsset asset)
    {
        if (_spriteLibrary == null)
        {
            return;
        }
        _spriteLibrary.spriteLibraryAsset = asset;
    }

    public void SetWalkingParameter(bool isWalking)
    {
        _animator?.SetBool(_walkingAnimationParameter, isWalking);
    }
}
