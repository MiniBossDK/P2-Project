//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Sofie Folder/Scripts/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""TouchControls"",
            ""id"": ""5dfa2543-e1e0-41b4-ad95-cdeb371dd432"",
            ""actions"": [
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b0b790b5-4fdb-4f1b-a6b6-bd48004fe7ef"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""c428e74f-9b1a-4e66-b42d-8301b527be7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""45fd376e-8ef2-4b92-a1cf-73ac8ecb12e6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchHold"",
                    ""type"": ""Button"",
                    ""id"": ""130b18e0-621f-4bfd-b21b-56e4fbfba3ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a4a33d1a-25bb-4121-a49e-87774b55150f"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f4db4f3-dc80-481b-8c9b-6cd7115578c2"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b47868fa-6c05-4514-825f-922035c2bc4d"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""241d71b2-e75b-40c8-bd68-b552bd96a0c8"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchControls
        m_TouchControls = asset.FindActionMap("TouchControls", throwIfNotFound: true);
        m_TouchControls_TouchInput = m_TouchControls.FindAction("TouchInput", throwIfNotFound: true);
        m_TouchControls_TouchPress = m_TouchControls.FindAction("TouchPress", throwIfNotFound: true);
        m_TouchControls_TouchPosition = m_TouchControls.FindAction("TouchPosition", throwIfNotFound: true);
        m_TouchControls_TouchHold = m_TouchControls.FindAction("TouchHold", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // TouchControls
    private readonly InputActionMap m_TouchControls;
    private ITouchControlsActions m_TouchControlsActionsCallbackInterface;
    private readonly InputAction m_TouchControls_TouchInput;
    private readonly InputAction m_TouchControls_TouchPress;
    private readonly InputAction m_TouchControls_TouchPosition;
    private readonly InputAction m_TouchControls_TouchHold;
    public struct TouchControlsActions
    {
        private @Inputs m_Wrapper;
        public TouchControlsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchInput => m_Wrapper.m_TouchControls_TouchInput;
        public InputAction @TouchPress => m_Wrapper.m_TouchControls_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_TouchControls_TouchPosition;
        public InputAction @TouchHold => m_Wrapper.m_TouchControls_TouchHold;
        public InputActionMap Get() { return m_Wrapper.m_TouchControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchControlsActions set) { return set.Get(); }
        public void SetCallbacks(ITouchControlsActions instance)
        {
            if (m_Wrapper.m_TouchControlsActionsCallbackInterface != null)
            {
                @TouchInput.started -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchInput;
                @TouchPress.started -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchPosition;
                @TouchHold.started -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchHold;
                @TouchHold.performed -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchHold;
                @TouchHold.canceled -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnTouchHold;
            }
            m_Wrapper.m_TouchControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchHold.started += instance.OnTouchHold;
                @TouchHold.performed += instance.OnTouchHold;
                @TouchHold.canceled += instance.OnTouchHold;
            }
        }
    }
    public TouchControlsActions @TouchControls => new TouchControlsActions(this);
    public interface ITouchControlsActions
    {
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchHold(InputAction.CallbackContext context);
    }
}
