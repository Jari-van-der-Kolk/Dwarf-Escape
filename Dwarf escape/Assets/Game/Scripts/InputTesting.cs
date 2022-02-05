using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTesting : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();

        _playerInput.onActionTriggered += Fuckyou;
    }
    
    private void Fuckyou(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Fuck you");
        }
    }
}
