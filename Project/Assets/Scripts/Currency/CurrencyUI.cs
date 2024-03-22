using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrencyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _label;

    private void Awake()
    {
        if (_label == null)
        {
            _label = GetComponent<TextMeshProUGUI>();
        }    
    }

    private void OnEnable()
    {
        CurrencyManager.OnValueChangedEvent += UpdateLabel;
    }

    private void OnDisable()
    {
        CurrencyManager.OnValueChangedEvent -= UpdateLabel;
    }

    private void UpdateLabel(int newValue, int delta)
    {
        if (_label == null)
        {
            return;
        }
        _label.text = newValue.ToString();
    }
}
