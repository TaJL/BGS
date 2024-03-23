using UnityEngine;

[RequireComponent(typeof(PlayableCharacterInputsCaster))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private PlayableCharacterInputsCaster _inputCaster;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _walkingAnimationParameter = "IsWalking";
    private Vector3 _scale;
    private Vector2 _velocity;

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
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
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
        _velocity = 5 * vector;
        FlipCheck(vector.x);
        _animator?.SetBool(_walkingAnimationParameter, vector.magnitude > Mathf.Epsilon);
    }

    private void FlipCheck(float direction)
    {
        if (direction != 0)
        {
            _scale.x = Mathf.Sign(direction);
            transform.localScale = _scale;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;    
    }
}