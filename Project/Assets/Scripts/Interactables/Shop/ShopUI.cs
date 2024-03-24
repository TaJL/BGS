using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private void OnEnable()
    {
        Shop.OnStartShoppingEvent += UpdateVisuals;    
    }

    private void OnDisable()
    {
        
    }
}