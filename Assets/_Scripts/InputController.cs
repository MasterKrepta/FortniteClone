using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, Controls.IPlayerActions
{
    // Start is called b
      public Vector2 MovementValue { get; private set; }

    private Controls _controls;
    private void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);

        _controls.Player.Enable();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
       MovementValue = context.ReadValue<Vector2>();
    }

    public void OnAiming(InputAction.CallbackContext context)
    {
       
    }
}
