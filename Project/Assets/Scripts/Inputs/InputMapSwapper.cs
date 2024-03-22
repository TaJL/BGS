using System.Collections;
using System.Collections.Generic;
using ReusedCode;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapSwapper : SingletonMonoBehaviour<InputMapSwapper>
{
    [SerializeField] private PlayerInput _playerInput;

    private const string MENU_MAP = "Menu";
    private const string CHARACTER_MAP = "Character";

    protected override void Awake()
    {
        base.Awake();
        if (_playerInput == null)
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        if (_playerInput == null)
        {
            return;
        }
        SwapToCharacterMap();
    }

    private void SwapToCharacterMap()
    {
        _playerInput.SwitchCurrentActionMap(CHARACTER_MAP);
    }

    private void SwapToMenuMap()
    {
        _playerInput.SwitchCurrentActionMap(MENU_MAP);
    }
}
