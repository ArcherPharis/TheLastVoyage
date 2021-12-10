// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""e9dc9850-547b-4bc1-b1e5-d11c8f9d32c6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""00fdd782-a7be-42ea-a9dd-c524ed6a0c0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e8764259-2a3a-46dc-b5ab-a0230e669ee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47ae6f3b-836a-4745-992c-2665d4853622"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""dd8dcf87-abd8-49d8-a9c5-ebb27a2a705e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""d9166ecf-b321-468a-afa8-822457f26b30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lift"",
                    ""type"": ""Button"",
                    ""id"": ""ca621bf1-2544-41d9-87f3-9179d23514e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""fb0f5072-61bc-4dde-9084-0d4f18cf4793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Power1"",
                    ""type"": ""Button"",
                    ""id"": ""8327cae7-149f-42a1-ad2c-4816fe032af2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6b15b4e2-31bf-40ac-975e-3dc6f66eaa03"",
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
                    ""id"": ""1ac55f9c-a566-4f8e-ba2e-3fb1b7386f28"",
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
                    ""id"": ""b6b8df5e-b445-440a-9d59-cb6c391e68f8"",
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
                    ""id"": ""4282301e-2409-4f8a-b839-fe09cfaaacf2"",
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
                    ""id"": ""9a4bdde2-4239-4910-981e-96841091dd4c"",
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
                    ""id"": ""53373eb0-a74e-4309-b084-552430a6ee39"",
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
                    ""id"": ""a51f117e-56de-4ac6-9f3c-b914c04bfa5f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f3dd005-2a34-4132-b7c4-0cce3020a54a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6e6bcee-e94a-4f01-ba5f-37b4f0e3ee97"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Hold(duration=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dcb5d4f-2596-4c92-b535-3e2f15afa806"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b7e43ca-36a0-4475-9061-34991c842e50"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16ba780f-6649-4708-903d-8e8aaceb8eda"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Power1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""088639c6-a15a-4a78-a30f-79fa922730d6"",
            ""actions"": [
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""c4a8e151-41b8-4917-9931-d6325db0810b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""088bcd2f-a77f-4fca-9a54-56166a69317b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2d75c534-30da-4bd0-93cb-c3df046fdc28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e5b377bb-3bf0-4542-842b-d234ddb22d92"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cb2ad2c-66f3-4675-8f95-20428e29baa3"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d10c15d2-3e2d-4f0f-919b-87c09a11a77a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Look = m_PlayerMovement.FindAction("Look", throwIfNotFound: true);
        m_PlayerMovement_Interact = m_PlayerMovement.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMovement_Run = m_PlayerMovement.FindAction("Run", throwIfNotFound: true);
        m_PlayerMovement_Lift = m_PlayerMovement.FindAction("Lift", throwIfNotFound: true);
        m_PlayerMovement_Throw = m_PlayerMovement.FindAction("Throw", throwIfNotFound: true);
        m_PlayerMovement_Power1 = m_PlayerMovement.FindAction("Power1", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Save = m_UI.FindAction("Save", throwIfNotFound: true);
        m_UI_Load = m_UI.FindAction("Load", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Look;
    private readonly InputAction m_PlayerMovement_Interact;
    private readonly InputAction m_PlayerMovement_Run;
    private readonly InputAction m_PlayerMovement_Lift;
    private readonly InputAction m_PlayerMovement_Throw;
    private readonly InputAction m_PlayerMovement_Power1;
    public struct PlayerMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Look => m_Wrapper.m_PlayerMovement_Look;
        public InputAction @Interact => m_Wrapper.m_PlayerMovement_Interact;
        public InputAction @Run => m_Wrapper.m_PlayerMovement_Run;
        public InputAction @Lift => m_Wrapper.m_PlayerMovement_Lift;
        public InputAction @Throw => m_Wrapper.m_PlayerMovement_Throw;
        public InputAction @Power1 => m_Wrapper.m_PlayerMovement_Power1;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Interact.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnInteract;
                @Run.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRun;
                @Lift.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLift;
                @Lift.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLift;
                @Lift.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLift;
                @Throw.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnThrow;
                @Power1.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPower1;
                @Power1.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPower1;
                @Power1.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPower1;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Lift.started += instance.OnLift;
                @Lift.performed += instance.OnLift;
                @Lift.canceled += instance.OnLift;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Power1.started += instance.OnPower1;
                @Power1.performed += instance.OnPower1;
                @Power1.canceled += instance.OnPower1;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Save;
    private readonly InputAction m_UI_Load;
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @PlayerInputs m_Wrapper;
        public UIActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Save => m_Wrapper.m_UI_Save;
        public InputAction @Load => m_Wrapper.m_UI_Load;
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Save.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSave;
                @Load.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLoad;
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLift(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnPower1(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSave(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
