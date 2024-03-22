using UnityEngine;

[RequireComponent(typeof(PlayableCharacterInputsCaster))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private PlayableCharacterInputsCaster _inputCaster;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector3 _scale;

    private void Awake()
    {
        if (_inputCaster == null)
        {
            _inputCaster = GetComponent<PlayableCharacterInputsCaster>();
        }
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        _scale = transform.localScale;
    }

    private void OnEnable()
    {
        _inputCaster.OnMovementChangedEvent += UpdateMovement;    
    }

    private void OnDisable()
    {
        _inputCaster.OnMovementChangedEvent -= UpdateMovement;    
    }

    private void UpdateMovement(Vector2 vector)
    {
        _rigidbody.velocity = 5 * vector;
        if (vector.x != 0)
        {
            _scale.x = Mathf.Sign(vector.x);
            transform.localScale = _scale;
        }
    }
}
