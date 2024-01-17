using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;
    
    private PlayerInputActions playerInputs;

    private Vector2 leftAxisValue = Vector2.zero;  // Keyboard [WASD]

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInputs = new PlayerInputActions();
            
            playerInputs.Character.Enable();
            playerInputs.Character.Movement.performed += LeftAxisUpdate;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        InputSystem.Update();
    }

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();
    }

    public Vector2 GetLeftAxisValue()
    {
        return leftAxisValue;
    }
}
