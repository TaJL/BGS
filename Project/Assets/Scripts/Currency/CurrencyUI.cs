using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrencyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _valueLabel;
    [SerializeField] private TextMeshProUGUI _deltaLabel;
    [SerializeField, Tooltip("It adapts to show big variations for longer.")] private float _baseAnimation;
    [SerializeField] private Color _gainColor;
    [SerializeField] private Color _lossColor;
    private int _value;

    private void Awake()
    {
        if (_valueLabel == null)
        {
            _valueLabel = GetComponent<TextMeshProUGUI>();
        }    
    }

    private void OnEnable()
    {
        CurrencyManager.OnValueChangedEvent += UpdateValue;
    }

    private void OnDisable()
    {
        CurrencyManager.OnValueChangedEvent -= UpdateValue;
    }

    private void UpdateValue(int newValue, int delta)
    {
        float animationTime = _baseAnimation * Mathf.Abs(delta);
        LeanTween.value(gameObject, _value, newValue, animationTime).
            setOnUpdate(UpdateLabel);
        
        if (delta > 0)
        {
            _deltaLabel.text = $"+{delta}";
            _deltaLabel.color = _gainColor;
        }
        else
        {
            _deltaLabel.text = delta.ToString();
            _deltaLabel.color = _lossColor;
        }
        LeanTween.value(_deltaLabel.gameObject, 2, 0, animationTime).
            setOnUpdate(UpdateDeltaLaberAlpha);
    }

    private void UpdateLabel(float value)
    {
        if (_valueLabel == null)
        {
            return;
        }
        _value = Mathf.RoundToInt(value);
        _valueLabel.text = $"$ {_value}";
    }

    private void UpdateDeltaLaberAlpha(float alpha)
    {
        print(alpha);
        Color color = _deltaLabel.color;
        color.a = alpha;
        _deltaLabel.color = color;
    }
}
