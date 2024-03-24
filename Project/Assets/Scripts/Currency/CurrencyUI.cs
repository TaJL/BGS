using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _valueLabel;
    [SerializeField] private TextMeshProUGUI _deltaLabel;
    [SerializeField, Tooltip("It adapts to show big variations for longer.")] private float _baseAnimation;
    [SerializeField] private Color _gainColor;
    [SerializeField] private Color _lossColor;
    [SerializeField] private AudioClip[] _variationClips;
    [SerializeField] private AudioSource _audioSource;
    
    private int _value;

    private void Awake()
    {
        if (_valueLabel == null)
        {
            _valueLabel = GetComponent<TextMeshProUGUI>();
        }
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
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
        if (_valueLabel == null ||
            Mathf.RoundToInt(value) == _value)
        {
            return;
        }
        _value = Mathf.RoundToInt(value);
        _valueLabel.text = $"$ {_value}";
        if (_audioSource.isPlaying == false)
        {
            _audioSource.clip = _variationClips[Random.Range(0, _variationClips.Length)];
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.Play();
        }
    }

    private void UpdateDeltaLaberAlpha(float alpha)
    {
        Color color = _deltaLabel.color;
        color.a = alpha;
        _deltaLabel.color = color;
    }
}
