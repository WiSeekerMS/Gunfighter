//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Resources/Controls/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""e5b68c12-260a-4776-942b-f412daa4822c"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""7405842f-0ccc-4412-a2bc-bc60fa2e0d12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""11fdc6c2-5c2c-4738-bb50-e6b955d9ea2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""cd8e360d-2a10-4399-a01e-d5d872974f77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AxisX"",
                    ""type"": ""Value"",
                    ""id"": ""c54a5d21-80d0-45e7-b3cf-e1fd84aa9b85"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AxisY"",
                    ""type"": ""Value"",
                    ""id"": ""2f298297-2c84-460b-b22a-6f9e80a26a7b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""cd3d850b-63e5-4ea8-80da-bce88b2f1a89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ButtonAxisX"",
                    ""type"": ""Value"",
                    ""id"": ""b2808146-6c2b-4460-9354-ecba0636b152"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ButtonAxisY"",
                    ""type"": ""Button"",
                    ""id"": ""64e8b784-cfb2-4d77-86b7-4c42d5f27c32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""353848b7-d194-4a76-bc9c-27ed8de3ffa9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""16f96fb7-b882-4fc6-9ce1-4c8bc178aae6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BothWeapons"",
                    ""type"": ""Button"",
                    ""id"": ""b68bf262-f26e-421f-b854-8feeb12fbf2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""825e4228-630d-4c18-9bf7-19126d1b8848"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2a34f6c-b69c-4a33-b4cf-3b0c27a7b7a6"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a65cea7-b9c1-4cce-8af3-2a99a6e8c466"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e190ed43-1bd2-47ff-b5b2-6841a33668b0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""446893ba-339d-472e-a32e-00dcc4392875"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""AxisX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5152b9e5-c66d-4383-baeb-aa0706a11de7"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AxisX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53852ed2-b2d8-40d1-bc00-3f3aee4f6340"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""AxisY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd495bef-10d3-4132-9cf6-e1a271d548cc"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AxisY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0173368f-0091-47d5-a7a3-58590904ca9b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""476a739d-6e5e-42bb-ac08-a6320125870b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9de8cceb-589e-4171-9643-d583500fd117"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAxisX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0739953e-655e-419d-84c7-0927c8f0c2e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""ButtonAxisX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dd95ee85-a74c-4fe1-bddf-ba1c03744af3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""ButtonAxisX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""cdba7f07-e06d-4247-80aa-3a6fc1e72e40"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonAxisY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""be58e540-e25f-4553-bf16-c1e7450a7241"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""ButtonAxisY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9974fc20-c5ee-4715-8d2d-f0bc1c850dcc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse"",
                    ""action"": ""ButtonAxisY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e054c699-30ab-4935-8563-8a5fee7405c8"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfc80913-d852-4dac-867c-5b4984845778"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b5e7734-024b-4688-b6de-6f463b59565e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BothWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard + Mouse"",
            ""bindingGroup"": ""Keyboard + Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Quit = m_Main.FindAction("Quit", throwIfNotFound: true);
        m_Main_Shot = m_Main.FindAction("Shot", throwIfNotFound: true);
        m_Main_Aim = m_Main.FindAction("Aim", throwIfNotFound: true);
        m_Main_AxisX = m_Main.FindAction("AxisX", throwIfNotFound: true);
        m_Main_AxisY = m_Main.FindAction("AxisY", throwIfNotFound: true);
        m_Main_Reload = m_Main.FindAction("Reload", throwIfNotFound: true);
        m_Main_ButtonAxisX = m_Main.FindAction("ButtonAxisX", throwIfNotFound: true);
        m_Main_ButtonAxisY = m_Main.FindAction("ButtonAxisY", throwIfNotFound: true);
        m_Main_LeftWeapon = m_Main.FindAction("LeftWeapon", throwIfNotFound: true);
        m_Main_RightWeapon = m_Main.FindAction("RightWeapon", throwIfNotFound: true);
        m_Main_BothWeapons = m_Main.FindAction("BothWeapons", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Quit;
    private readonly InputAction m_Main_Shot;
    private readonly InputAction m_Main_Aim;
    private readonly InputAction m_Main_AxisX;
    private readonly InputAction m_Main_AxisY;
    private readonly InputAction m_Main_Reload;
    private readonly InputAction m_Main_ButtonAxisX;
    private readonly InputAction m_Main_ButtonAxisY;
    private readonly InputAction m_Main_LeftWeapon;
    private readonly InputAction m_Main_RightWeapon;
    private readonly InputAction m_Main_BothWeapons;
    public struct MainActions
    {
        private @Controls m_Wrapper;
        public MainActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_Main_Quit;
        public InputAction @Shot => m_Wrapper.m_Main_Shot;
        public InputAction @Aim => m_Wrapper.m_Main_Aim;
        public InputAction @AxisX => m_Wrapper.m_Main_AxisX;
        public InputAction @AxisY => m_Wrapper.m_Main_AxisY;
        public InputAction @Reload => m_Wrapper.m_Main_Reload;
        public InputAction @ButtonAxisX => m_Wrapper.m_Main_ButtonAxisX;
        public InputAction @ButtonAxisY => m_Wrapper.m_Main_ButtonAxisY;
        public InputAction @LeftWeapon => m_Wrapper.m_Main_LeftWeapon;
        public InputAction @RightWeapon => m_Wrapper.m_Main_RightWeapon;
        public InputAction @BothWeapons => m_Wrapper.m_Main_BothWeapons;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_MainActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnQuit;
                @Shot.started -= m_Wrapper.m_MainActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnShot;
                @Aim.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAim;
                @AxisX.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAxisX;
                @AxisX.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAxisX;
                @AxisX.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAxisX;
                @AxisY.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAxisY;
                @AxisY.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAxisY;
                @AxisY.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAxisY;
                @Reload.started -= m_Wrapper.m_MainActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnReload;
                @ButtonAxisX.started -= m_Wrapper.m_MainActionsCallbackInterface.OnButtonAxisX;
                @ButtonAxisX.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnButtonAxisX;
                @ButtonAxisX.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnButtonAxisX;
                @ButtonAxisY.started -= m_Wrapper.m_MainActionsCallbackInterface.OnButtonAxisY;
                @ButtonAxisY.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnButtonAxisY;
                @ButtonAxisY.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnButtonAxisY;
                @LeftWeapon.started -= m_Wrapper.m_MainActionsCallbackInterface.OnLeftWeapon;
                @LeftWeapon.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnLeftWeapon;
                @LeftWeapon.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnLeftWeapon;
                @RightWeapon.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRightWeapon;
                @RightWeapon.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRightWeapon;
                @RightWeapon.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRightWeapon;
                @BothWeapons.started -= m_Wrapper.m_MainActionsCallbackInterface.OnBothWeapons;
                @BothWeapons.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnBothWeapons;
                @BothWeapons.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnBothWeapons;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @AxisX.started += instance.OnAxisX;
                @AxisX.performed += instance.OnAxisX;
                @AxisX.canceled += instance.OnAxisX;
                @AxisY.started += instance.OnAxisY;
                @AxisY.performed += instance.OnAxisY;
                @AxisY.canceled += instance.OnAxisY;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @ButtonAxisX.started += instance.OnButtonAxisX;
                @ButtonAxisX.performed += instance.OnButtonAxisX;
                @ButtonAxisX.canceled += instance.OnButtonAxisX;
                @ButtonAxisY.started += instance.OnButtonAxisY;
                @ButtonAxisY.performed += instance.OnButtonAxisY;
                @ButtonAxisY.canceled += instance.OnButtonAxisY;
                @LeftWeapon.started += instance.OnLeftWeapon;
                @LeftWeapon.performed += instance.OnLeftWeapon;
                @LeftWeapon.canceled += instance.OnLeftWeapon;
                @RightWeapon.started += instance.OnRightWeapon;
                @RightWeapon.performed += instance.OnRightWeapon;
                @RightWeapon.canceled += instance.OnRightWeapon;
                @BothWeapons.started += instance.OnBothWeapons;
                @BothWeapons.performed += instance.OnBothWeapons;
                @BothWeapons.canceled += instance.OnBothWeapons;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard + Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAxisX(InputAction.CallbackContext context);
        void OnAxisY(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnButtonAxisX(InputAction.CallbackContext context);
        void OnButtonAxisY(InputAction.CallbackContext context);
        void OnLeftWeapon(InputAction.CallbackContext context);
        void OnRightWeapon(InputAction.CallbackContext context);
        void OnBothWeapons(InputAction.CallbackContext context);
    }
}
