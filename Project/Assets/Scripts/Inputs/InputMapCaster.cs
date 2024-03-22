using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ReusedCode
{
    public abstract class InputMapCaster : MonoBehaviour
    {
        [SerializeField] protected PlayerInput playerInput;

        protected void SubscribeToAction(string actionName, InputActionPhase phase, Action<InputAction.CallbackContext> method)
        {
            InputAction action = playerInput.actions[actionName];
            if (action == null)
            {
                return;
            }
            switch (phase)
            {
                case InputActionPhase.Started:
                {
                    action.started += method;
                    break;
                }
                case InputActionPhase.Performed:
                {
                    action.performed += method;
                    break;
                }
                case InputActionPhase.Canceled:
                {
                    action.canceled += method;
                    break;
                }
            }
        }

        protected void UnsubscribeToAction(string actionName, InputActionPhase phase, Action<InputAction.CallbackContext> method)
        {
            InputAction action = playerInput.actions[actionName];
            if (action == null)
            {
                return;
            }
            switch (phase)
            {
                case InputActionPhase.Started:
                {
                    action.started -= method;
                    break;
                }
                case InputActionPhase.Performed:
                {
                    action.performed -= method;
                    break;
                }
                case InputActionPhase.Canceled:
                {
                    action.canceled -= method;
                    break;
                }
            }
        }
    }
}