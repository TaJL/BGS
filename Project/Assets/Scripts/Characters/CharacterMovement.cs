using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayableCharacterInputsCaster))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private PlayableCharacterInputsCaster _inputCaster;
    [SerializeField] private Rigidbody2D _rigidbody;

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
    }
}
