//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputActions/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMovementActionMap"",
            ""id"": ""c13b8f45-3b91-44c5-9669-7eb50abbab83"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9f270aa1-575f-4f20-b8fb-a21ff8a35501"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8b9c16c3-b7bc-4b75-ab67-4a653bd0db8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FastMovement"",
                    ""type"": ""Button"",
                    ""id"": ""495c2739-81e8-41c9-b226-de541674209c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5fe8d47e-8581-4c89-bbd9-b61df4877da3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fbcd53f4-735d-470d-8ad2-e38b286bbcf5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d0a64994-9e3d-454c-a6e4-61d60a198aa1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9b814b0b-336f-465e-97fe-e1fb393cf55d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ce017877-906d-4619-8387-1516910d0334"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""790aca42-d786-49a5-9346-d560e32b90a6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66ae5467-da14-4fa4-815a-5d9fbe355fce"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerAttackActionMap"",
            ""id"": ""35903cdc-10d4-4bda-af8d-b450ac6654c7"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""b100bd84-072e-4204-884b-f280384a1fb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1cf6c726-2f2d-4ba7-afde-258bbbffbabc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerGeneralActionMap"",
            ""id"": ""be9263c4-aa0f-4383-a546-fbb05dd0735f"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""34888032-04e6-45ef-95e7-301fa4335c41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchRotationType"",
                    ""type"": ""Button"",
                    ""id"": ""2963990b-3fcc-4407-b795-70502e0a0098"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e09c9ce8-d072-4d16-83d5-b41d3b9a2cc0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone(min=0.5)"",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookZoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""545a4319-d233-453c-9556-9ee896ac1461"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookAtMousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""ddc60c4c-0c37-4618-83a4-3558f52788e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b252a63c-5cce-48e6-96aa-7209acff9c33"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector Gamepad"",
                    ""id"": ""d4f30552-d958-4473-abd4-9182ba065f92"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ea340147-f966-4dc6-b341-ad049956e9b4"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""18ff3ae9-ecd3-433a-ad90-f1aad7157e2b"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9e74c0ea-504e-4633-8555-111d9ce4a7e8"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9c658061-b63c-4f4e-9d39-c72ef759212a"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1eaa6102-0b01-41ce-b56d-19ad4b17136a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ead900f-4443-4d45-a269-068b4a2cf1fe"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e16405e-d255-4356-89e5-86b09d91ae99"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAtMousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59e6b90e-e0c8-4ada-a275-dbe93270c0d3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchRotationType"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovementActionMap
        m_PlayerMovementActionMap = asset.FindActionMap("PlayerMovementActionMap", throwIfNotFound: true);
        m_PlayerMovementActionMap_Movement = m_PlayerMovementActionMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovementActionMap_Jump = m_PlayerMovementActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovementActionMap_FastMovement = m_PlayerMovementActionMap.FindAction("FastMovement", throwIfNotFound: true);
        // PlayerAttackActionMap
        m_PlayerAttackActionMap = asset.FindActionMap("PlayerAttackActionMap", throwIfNotFound: true);
        m_PlayerAttackActionMap_Attack = m_PlayerAttackActionMap.FindAction("Attack", throwIfNotFound: true);
        // PlayerGeneralActionMap
        m_PlayerGeneralActionMap = asset.FindActionMap("PlayerGeneralActionMap", throwIfNotFound: true);
        m_PlayerGeneralActionMap_Interact = m_PlayerGeneralActionMap.FindAction("Interact", throwIfNotFound: true);
        m_PlayerGeneralActionMap_SwitchRotationType = m_PlayerGeneralActionMap.FindAction("SwitchRotationType", throwIfNotFound: true);
        m_PlayerGeneralActionMap_LookRotation = m_PlayerGeneralActionMap.FindAction("LookRotation", throwIfNotFound: true);
        m_PlayerGeneralActionMap_LookZoom = m_PlayerGeneralActionMap.FindAction("LookZoom", throwIfNotFound: true);
        m_PlayerGeneralActionMap_LookAtMousePosition = m_PlayerGeneralActionMap.FindAction("LookAtMousePosition", throwIfNotFound: true);
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

    // PlayerMovementActionMap
    private readonly InputActionMap m_PlayerMovementActionMap;
    private IPlayerMovementActionMapActions m_PlayerMovementActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementActionMap_Movement;
    private readonly InputAction m_PlayerMovementActionMap_Jump;
    private readonly InputAction m_PlayerMovementActionMap_FastMovement;
    public struct PlayerMovementActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerMovementActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovementActionMap_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMovementActionMap_Jump;
        public InputAction @FastMovement => m_Wrapper.m_PlayerMovementActionMap_FastMovement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnJump;
                @FastMovement.started -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnFastMovement;
                @FastMovement.performed -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnFastMovement;
                @FastMovement.canceled -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnFastMovement;
            }
            m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FastMovement.started += instance.OnFastMovement;
                @FastMovement.performed += instance.OnFastMovement;
                @FastMovement.canceled += instance.OnFastMovement;
            }
        }
    }
    public PlayerMovementActionMapActions @PlayerMovementActionMap => new PlayerMovementActionMapActions(this);

    // PlayerAttackActionMap
    private readonly InputActionMap m_PlayerAttackActionMap;
    private IPlayerAttackActionMapActions m_PlayerAttackActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerAttackActionMap_Attack;
    public struct PlayerAttackActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerAttackActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_PlayerAttackActionMap_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAttackActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerAttackActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerAttackActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerAttackActionMapActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_PlayerAttackActionMapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerAttackActionMapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerAttackActionMapActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerAttackActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerAttackActionMapActions @PlayerAttackActionMap => new PlayerAttackActionMapActions(this);

    // PlayerGeneralActionMap
    private readonly InputActionMap m_PlayerGeneralActionMap;
    private IPlayerGeneralActionMapActions m_PlayerGeneralActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerGeneralActionMap_Interact;
    private readonly InputAction m_PlayerGeneralActionMap_SwitchRotationType;
    private readonly InputAction m_PlayerGeneralActionMap_LookRotation;
    private readonly InputAction m_PlayerGeneralActionMap_LookZoom;
    private readonly InputAction m_PlayerGeneralActionMap_LookAtMousePosition;
    public struct PlayerGeneralActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerGeneralActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_PlayerGeneralActionMap_Interact;
        public InputAction @SwitchRotationType => m_Wrapper.m_PlayerGeneralActionMap_SwitchRotationType;
        public InputAction @LookRotation => m_Wrapper.m_PlayerGeneralActionMap_LookRotation;
        public InputAction @LookZoom => m_Wrapper.m_PlayerGeneralActionMap_LookZoom;
        public InputAction @LookAtMousePosition => m_Wrapper.m_PlayerGeneralActionMap_LookAtMousePosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerGeneralActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerGeneralActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerGeneralActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnInteract;
                @SwitchRotationType.started -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnSwitchRotationType;
                @SwitchRotationType.performed -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnSwitchRotationType;
                @SwitchRotationType.canceled -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnSwitchRotationType;
                @LookRotation.started -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookRotation;
                @LookRotation.performed -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookRotation;
                @LookRotation.canceled -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookRotation;
                @LookZoom.started -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookZoom;
                @LookZoom.performed -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookZoom;
                @LookZoom.canceled -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookZoom;
                @LookAtMousePosition.started -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookAtMousePosition;
                @LookAtMousePosition.performed -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookAtMousePosition;
                @LookAtMousePosition.canceled -= m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface.OnLookAtMousePosition;
            }
            m_Wrapper.m_PlayerGeneralActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SwitchRotationType.started += instance.OnSwitchRotationType;
                @SwitchRotationType.performed += instance.OnSwitchRotationType;
                @SwitchRotationType.canceled += instance.OnSwitchRotationType;
                @LookRotation.started += instance.OnLookRotation;
                @LookRotation.performed += instance.OnLookRotation;
                @LookRotation.canceled += instance.OnLookRotation;
                @LookZoom.started += instance.OnLookZoom;
                @LookZoom.performed += instance.OnLookZoom;
                @LookZoom.canceled += instance.OnLookZoom;
                @LookAtMousePosition.started += instance.OnLookAtMousePosition;
                @LookAtMousePosition.performed += instance.OnLookAtMousePosition;
                @LookAtMousePosition.canceled += instance.OnLookAtMousePosition;
            }
        }
    }
    public PlayerGeneralActionMapActions @PlayerGeneralActionMap => new PlayerGeneralActionMapActions(this);
    public interface IPlayerMovementActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFastMovement(InputAction.CallbackContext context);
    }
    public interface IPlayerAttackActionMapActions
    {
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IPlayerGeneralActionMapActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnSwitchRotationType(InputAction.CallbackContext context);
        void OnLookRotation(InputAction.CallbackContext context);
        void OnLookZoom(InputAction.CallbackContext context);
        void OnLookAtMousePosition(InputAction.CallbackContext context);
    }
}