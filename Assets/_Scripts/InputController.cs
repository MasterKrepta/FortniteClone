using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }

    public bool IsSprinting { get; private set; }

    public Action OnSprintEvent;
    public Action OnShootEvent;

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

    public void OnSprint(InputAction.CallbackContext context)
    {
 
        if (context.performed) IsSprinting = true;
        if (context.canceled) IsSprinting = false;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
    }

    public void OnBuildMode(InputAction.CallbackContext context)
    {
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnShootEvent?.Invoke();
    }
}
