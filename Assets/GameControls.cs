// GENERATED AUTOMATICALLY FROM 'Assets/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""81ebdb89-6032-4dc8-839d-e8372b134649"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""1f5433d1-edf1-42c1-9041-56e13963dae2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""cfbad466-b31e-4953-8986-634e84b857b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e2f983d9-0f9c-4b0a-845d-81a887737f2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD 2DVector"",
                    ""id"": ""4bf1ce9d-4f7e-4158-ad31-d2e28de125d4"",
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
                    ""id"": ""f641d1b1-c050-4a33-ac14-f2eb77d9cbff"",
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
                    ""id"": ""3074fec6-aec6-493b-876b-9fbf8ff18549"",
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
                    ""id"": ""2f4ac5fa-30fc-4129-bf92-4dcc25324898"",
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
                    ""id"": ""e3165ba3-4ae6-41ba-9459-7428fb2ff47a"",
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
                    ""id"": ""4935de03-cbb3-44de-abb7-971eb942054b"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c693f885-cd35-4e52-9d05-47dfc2eb92ec"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_Movement = m_Input.FindAction("Movement", throwIfNotFound: true);
        m_Input_Attack = m_Input.FindAction("Attack", throwIfNotFound: true);
        m_Input_Interact = m_Input.FindAction("Interact", throwIfNotFound: true);
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

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_Movement;
    private readonly InputAction m_Input_Attack;
    private readonly InputAction m_Input_Interact;
    public struct InputActions
    {
        private @GameControls m_Wrapper;
        public InputActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Input_Movement;
        public InputAction @Attack => m_Wrapper.m_Input_Attack;
        public InputAction @Interact => m_Wrapper.m_Input_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_InputActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnAttack;
                @Interact.started -= m_Wrapper.m_InputActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InputActions @Input => new InputActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
