using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InputManager : SingletonPattern<InputManager>
{
    public delegate void StartHold(Vector2 pos);
    public event StartHold StartHoldEvent;

    public delegate void PerformedHold(Vector2 pos);
    public event PerformedHold PerformedHoldEvent;

    public delegate void PerformedInput(Vector2 pos);
    public event PerformedHold PerformedInputEvent;

    public delegate void EndHold(Vector2 pos);
    public event EndHold EndHoldEvent;

    public Inputs input;


    void Start()
    {

        input.TouchControls.TouchPress.canceled += ctx => OnEndHold(ctx);
        input.TouchControls.TouchHold.performed += ctx => OnStartHold(ctx);
        input.TouchControls.TouchInput.performed += ctx => OnPerformedHold(ctx);

    }

    private void Awake()
    {
        input = new Inputs();
    }

    private void OnEnable()
    {
        input.TouchControls.Enable();
    }

    private void OnDisable()
    {
        input.TouchControls.Disable();
    }

    private void OnStartHold(InputAction.CallbackContext ctx)
    {
        if (StartHoldEvent != null) StartHoldEvent(input.TouchControls.TouchPosition.ReadValue<Vector2>());
    }

    private void OnEndHold(InputAction.CallbackContext ctx)
    {
        if (EndHoldEvent != null) EndHoldEvent(input.TouchControls.TouchPosition.ReadValue<Vector2>());
    }

    private void OnPerformedHold(InputAction.CallbackContext ctx)
    {
        if (PerformedHoldEvent != null) PerformedHoldEvent(input.TouchControls.TouchPosition.ReadValue<Vector2>());
    }
}
