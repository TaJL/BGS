using System;
using UnityEngine;

[RequireComponent(typeof(PlayableCharacterInputsCaster))]
public class CharacterMovement : MonoBehaviour
{
    public Action<bool> OnIsWalkingEvent;

    [SerializeField] private PlayableCharacterInputsCaster _inputCaster;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private Vector3 _scale;
    private Vector2 _velocity;
    private bool _wasWalking;

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
        bool isWalking = vector.magnitude > Mathf.Epsilon;
        
        _velocity = _speed * vector;
        FlipCheck(vector.x);
        if (_wasWalking != isWalking)
        {
            OnIsWalkingEvent?.Invoke(isWalking);
        }
        _wasWalking = isWalking;
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