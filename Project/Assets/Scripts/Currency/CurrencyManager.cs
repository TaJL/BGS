using System;
using ReusedCode;
using UnityEngine;

public class CurrencyManager : SingletonMonoBehaviour<CurrencyManager>
{
    public static Action<int,int> OnValueChangedEvent;

    public override bool ShouldDestroyOnLoad => false;

    [SerializeField] private int _value = 0;

    public bool CanBuy(int itemValue)
    {
        return itemValue <= _value;
    }

    public void Modify(int delta)
    {
        if (delta < 0)
        {
            delta = Mathf.Max(-_value, delta);
        }
        if (delta == 0)
        {
            return;
        }
        _value += delta;
        OnValueChangedEvent?.Invoke(_value, delta);
    }
}