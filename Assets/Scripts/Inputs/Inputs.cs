//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Inputs/Inputs.inputactions
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

public partial class @Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f99fbf77-7dd6-4ae6-b787-177995f78fdc"",
            ""actions"": [
                {
                    ""name"": ""P1L"",
                    ""type"": ""Button"",
                    ""id"": ""bdec4525-58ac-4d2d-af11-f66cbacaf8c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P1R"",
                    ""type"": ""Button"",
                    ""id"": ""5fbc02ca-7d6b-42e1-a0ac-ae86f67cf37a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P2L"",
                    ""type"": ""Button"",
                    ""id"": ""460f8225-4ca9-420f-953e-6b327bfd28aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""P2R"",
                    ""type"": ""Button"",
                    ""id"": ""49c5eddb-7ea2-40af-81f6-d9f7c2f0a6d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ec67d36-2789-4732-bd49-10b961a27d78"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7a41b01-8df7-42ba-ac0f-5b08ab802f7a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95eb0c21-8f42-43ad-b4a2-7e883079417e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87bb5227-3add-4d36-869b-3c71b3580515"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gameplay"",
            ""bindingGroup"": ""Gameplay"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_P1L = m_Gameplay.FindAction("P1L", throwIfNotFound: true);
        m_Gameplay_P1R = m_Gameplay.FindAction("P1R", throwIfNotFound: true);
        m_Gameplay_P2L = m_Gameplay.FindAction("P2L", throwIfNotFound: true);
        m_Gameplay_P2R = m_Gameplay.FindAction("P2R", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_P1L;
    private readonly InputAction m_Gameplay_P1R;
    private readonly InputAction m_Gameplay_P2L;
    private readonly InputAction m_Gameplay_P2R;
    public struct GameplayActions
    {
        private @Inputs m_Wrapper;
        public GameplayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @P1L => m_Wrapper.m_Gameplay_P1L;
        public InputAction @P1R => m_Wrapper.m_Gameplay_P1R;
        public InputAction @P2L => m_Wrapper.m_Gameplay_P2L;
        public InputAction @P2R => m_Wrapper.m_Gameplay_P2R;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @P1L.started += instance.OnP1L;
            @P1L.performed += instance.OnP1L;
            @P1L.canceled += instance.OnP1L;
            @P1R.started += instance.OnP1R;
            @P1R.performed += instance.OnP1R;
            @P1R.canceled += instance.OnP1R;
            @P2L.started += instance.OnP2L;
            @P2L.performed += instance.OnP2L;
            @P2L.canceled += instance.OnP2L;
            @P2R.started += instance.OnP2R;
            @P2R.performed += instance.OnP2R;
            @P2R.canceled += instance.OnP2R;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @P1L.started -= instance.OnP1L;
            @P1L.performed -= instance.OnP1L;
            @P1L.canceled -= instance.OnP1L;
            @P1R.started -= instance.OnP1R;
            @P1R.performed -= instance.OnP1R;
            @P1R.canceled -= instance.OnP1R;
            @P2L.started -= instance.OnP2L;
            @P2L.performed -= instance.OnP2L;
            @P2L.canceled -= instance.OnP2L;
            @P2R.started -= instance.OnP2R;
            @P2R.performed -= instance.OnP2R;
            @P2R.canceled -= instance.OnP2R;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_GameplaySchemeIndex = -1;
    public InputControlScheme GameplayScheme
    {
        get
        {
            if (m_GameplaySchemeIndex == -1) m_GameplaySchemeIndex = asset.FindControlSchemeIndex("Gameplay");
            return asset.controlSchemes[m_GameplaySchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnP1L(InputAction.CallbackContext context);
        void OnP1R(InputAction.CallbackContext context);
        void OnP2L(InputAction.CallbackContext context);
        void OnP2R(InputAction.CallbackContext context);
    }
}
