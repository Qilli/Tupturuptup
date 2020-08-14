// GENERATED AUTOMATICALLY FROM 'Assets/SystemAssets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""c20425d1-7b3a-449a-9ecd-11912feebaff"",
            ""actions"": [
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Button"",
                    ""id"": ""0d5a71c7-9414-4672-b984-82b8aa7f48bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PanMouseStatus"",
                    ""type"": ""Button"",
                    ""id"": ""73abac48-ed8e-4558-b9f1-59aa055ee164"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pan"",
                    ""type"": ""Button"",
                    ""id"": ""7d91b0a6-e982-4fce-b499-e29463ada58d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseOffset"",
                    ""type"": ""Button"",
                    ""id"": ""6a4f8d36-daa8-45d0-bd2d-a66497746585"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf8affe4-2de1-4ce8-b90b-7394abb0aa35"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""PanMouseStatus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8594ba53-6987-4866-8b1d-64b4bae3137c"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""PanMovement"",
                    ""id"": ""767964e9-14e0-4375-b6c9-b5f15986bbe3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""40380edc-fa59-47d1-9856-786d7f6e1987"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ad03c46c-fb9d-4e5d-b160-8773c272e4e9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""39085389-6387-40ad-b443-00e72b2441b6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4a6c9bcd-38fe-43fa-bcab-d0b4b10a800a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4833b02b-a0d9-4c27-8d62-693deeb19782"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc6200cd-1c7c-4a37-ad6f-00e4b7257f0e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""MouseOffset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MapInteraction"",
            ""id"": ""bc691b39-bc43-45af-9e12-abac2c5a6790"",
            ""actions"": [
                {
                    ""name"": ""MouseLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""21dd07f4-1c6d-4d9a-91d0-f39f95936437"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRightClick"",
                    ""type"": ""Button"",
                    ""id"": ""7700fdb0-21d5-4807-8f0e-1e5a53742a1d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Button"",
                    ""id"": ""9804e150-9a29-4dcc-9753-c689c6806dd7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLeftHold"",
                    ""type"": ""Button"",
                    ""id"": ""a77f0ab0-f6ca-41f2-9cc3-bf6cee6745ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b16864b5-2c00-4823-bdc7-7a4ebbd52358"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse And Keyboard"",
                    ""action"": ""MouseLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""673e3320-61ac-4b37-afb5-9e357c345ecf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""MouseRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d9fd534-e2f3-4f96-a7b5-366aa7badb52"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Mouse And Keyboard"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13a561ed-e859-44b5-99e0-94addbc68031"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Mouse And Keyboard"",
                    ""action"": ""MouseLeftHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse And Keyboard"",
            ""bindingGroup"": ""Mouse And Keyboard"",
            ""devices"": []
        }
    ]
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_CameraZoom = m_Camera.FindAction("CameraZoom", throwIfNotFound: true);
        m_Camera_PanMouseStatus = m_Camera.FindAction("PanMouseStatus", throwIfNotFound: true);
        m_Camera_Pan = m_Camera.FindAction("Pan", throwIfNotFound: true);
        m_Camera_MouseOffset = m_Camera.FindAction("MouseOffset", throwIfNotFound: true);
        // MapInteraction
        m_MapInteraction = asset.FindActionMap("MapInteraction", throwIfNotFound: true);
        m_MapInteraction_MouseLeftClick = m_MapInteraction.FindAction("MouseLeftClick", throwIfNotFound: true);
        m_MapInteraction_MouseRightClick = m_MapInteraction.FindAction("MouseRightClick", throwIfNotFound: true);
        m_MapInteraction_MousePosition = m_MapInteraction.FindAction("MousePosition", throwIfNotFound: true);
        m_MapInteraction_MouseLeftHold = m_MapInteraction.FindAction("MouseLeftHold", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_CameraZoom;
    private readonly InputAction m_Camera_PanMouseStatus;
    private readonly InputAction m_Camera_Pan;
    private readonly InputAction m_Camera_MouseOffset;
    public struct CameraActions
    {
        private @InputMaster m_Wrapper;
        public CameraActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraZoom => m_Wrapper.m_Camera_CameraZoom;
        public InputAction @PanMouseStatus => m_Wrapper.m_Camera_PanMouseStatus;
        public InputAction @Pan => m_Wrapper.m_Camera_Pan;
        public InputAction @MouseOffset => m_Wrapper.m_Camera_MouseOffset;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @CameraZoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnCameraZoom;
                @PanMouseStatus.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPanMouseStatus;
                @PanMouseStatus.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPanMouseStatus;
                @PanMouseStatus.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPanMouseStatus;
                @Pan.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnPan;
                @MouseOffset.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseOffset;
                @MouseOffset.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseOffset;
                @MouseOffset.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMouseOffset;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CameraZoom.started += instance.OnCameraZoom;
                @CameraZoom.performed += instance.OnCameraZoom;
                @CameraZoom.canceled += instance.OnCameraZoom;
                @PanMouseStatus.started += instance.OnPanMouseStatus;
                @PanMouseStatus.performed += instance.OnPanMouseStatus;
                @PanMouseStatus.canceled += instance.OnPanMouseStatus;
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @MouseOffset.started += instance.OnMouseOffset;
                @MouseOffset.performed += instance.OnMouseOffset;
                @MouseOffset.canceled += instance.OnMouseOffset;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // MapInteraction
    private readonly InputActionMap m_MapInteraction;
    private IMapInteractionActions m_MapInteractionActionsCallbackInterface;
    private readonly InputAction m_MapInteraction_MouseLeftClick;
    private readonly InputAction m_MapInteraction_MouseRightClick;
    private readonly InputAction m_MapInteraction_MousePosition;
    private readonly InputAction m_MapInteraction_MouseLeftHold;
    public struct MapInteractionActions
    {
        private @InputMaster m_Wrapper;
        public MapInteractionActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLeftClick => m_Wrapper.m_MapInteraction_MouseLeftClick;
        public InputAction @MouseRightClick => m_Wrapper.m_MapInteraction_MouseRightClick;
        public InputAction @MousePosition => m_Wrapper.m_MapInteraction_MousePosition;
        public InputAction @MouseLeftHold => m_Wrapper.m_MapInteraction_MouseLeftHold;
        public InputActionMap Get() { return m_Wrapper.m_MapInteraction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapInteractionActions set) { return set.Get(); }
        public void SetCallbacks(IMapInteractionActions instance)
        {
            if (m_Wrapper.m_MapInteractionActionsCallbackInterface != null)
            {
                @MouseLeftClick.started -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseLeftClick;
                @MouseRightClick.started -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.performed -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.canceled -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseRightClick;
                @MousePosition.started -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMousePosition;
                @MouseLeftHold.started -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseLeftHold;
                @MouseLeftHold.performed -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseLeftHold;
                @MouseLeftHold.canceled -= m_Wrapper.m_MapInteractionActionsCallbackInterface.OnMouseLeftHold;
            }
            m_Wrapper.m_MapInteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
                @MouseRightClick.started += instance.OnMouseRightClick;
                @MouseRightClick.performed += instance.OnMouseRightClick;
                @MouseRightClick.canceled += instance.OnMouseRightClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseLeftHold.started += instance.OnMouseLeftHold;
                @MouseLeftHold.performed += instance.OnMouseLeftHold;
                @MouseLeftHold.canceled += instance.OnMouseLeftHold;
            }
        }
    }
    public MapInteractionActions @MapInteraction => new MapInteractionActions(this);
    private int m_MouseAndKeyboardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyboardScheme
    {
        get
        {
            if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse And Keyboard");
            return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
        }
    }
    public interface ICameraActions
    {
        void OnCameraZoom(InputAction.CallbackContext context);
        void OnPanMouseStatus(InputAction.CallbackContext context);
        void OnPan(InputAction.CallbackContext context);
        void OnMouseOffset(InputAction.CallbackContext context);
    }
    public interface IMapInteractionActions
    {
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseLeftHold(InputAction.CallbackContext context);
    }
}
