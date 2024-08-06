//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""da44f6a6-fc56-47e7-84cc-f3ea7421545b"",
            ""actions"": [
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""52c8654e-eca6-4dee-a2ad-ef4af6850961"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""9afb9b85-dbe4-425f-b761-79309c7248ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a9bee1c4-9d33-406a-8b4b-dc5bec07eb61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""6c86d928-29cc-4b79-aee9-417b47c717d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""639dcd3c-0e33-445f-9da1-79764e8844ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwordAttack"",
                    ""type"": ""Button"",
                    ""id"": ""cb7c57eb-f7ab-42af-9115-d6bd8372421a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GunShot"",
                    ""type"": ""Button"",
                    ""id"": ""2c25a983-d7ff-40a5-ba85-bcbf40f5e1d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Potion"",
                    ""type"": ""Button"",
                    ""id"": ""943b8920-eb44-4b6f-babb-57e860eb30f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""f51f549c-16a7-4df6-a49a-2c19cbfb134a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SoundInfluence"",
                    ""type"": ""Button"",
                    ""id"": ""b0e9d4f9-1482-4c35-a8a8-3714a6226836"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SoundDomain"",
                    ""type"": ""Button"",
                    ""id"": ""637d504a-6224-44df-8655-e293d21862dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scream"",
                    ""type"": ""Button"",
                    ""id"": ""2410e3d9-db40-42a0-93b4-739f289d418b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StopGame"",
                    ""type"": ""Button"",
                    ""id"": ""8948d8cb-c51a-43f8-bff9-bb22900a0bc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""1b409dd5-212f-4437-a2f2-623b2cac10cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""488a99e6-28d9-40ae-b728-d955cae40206"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""044ca987-32bf-4958-baea-55f7dcdb6a16"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf2bb108-ea41-4031-998f-3d5258ba0043"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5dfa8a4-0733-4fa6-af45-7877ddced3c0"",
                    ""path"": ""<XInputController>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""950a80f7-1201-4740-b88b-3f18c5cd04d9"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b7d6b9c-2425-4314-8907-951c78eec0a7"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwordAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88e9c50d-ebb2-481a-a7e2-3f5144e42c5e"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GunShot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94157752-cfb1-44cd-9bd3-0ea37f1878df"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7a37e88-db36-4aa4-93e2-4eb33fbdd275"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca7037e7-fe35-49cc-a24d-69f4074943d8"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoundInfluence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dd2985f-3036-4bc6-aefd-4ebeacb4f30d"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SoundDomain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a89856e0-2ba1-423c-a765-3bb3879aed76"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scream"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a6140c0-1b7f-4b12-9d21-b97b4789d15e"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34e706d1-066a-4d85-9058-a5cd44a43c32"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveRight = m_Gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_Gameplay_MoveLeft = m_Gameplay.FindAction("MoveLeft", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Crouch = m_Gameplay.FindAction("Crouch", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_SwordAttack = m_Gameplay.FindAction("SwordAttack", throwIfNotFound: true);
        m_Gameplay_GunShot = m_Gameplay.FindAction("GunShot", throwIfNotFound: true);
        m_Gameplay_Potion = m_Gameplay.FindAction("Potion", throwIfNotFound: true);
        m_Gameplay_Save = m_Gameplay.FindAction("Save", throwIfNotFound: true);
        m_Gameplay_SoundInfluence = m_Gameplay.FindAction("SoundInfluence", throwIfNotFound: true);
        m_Gameplay_SoundDomain = m_Gameplay.FindAction("SoundDomain", throwIfNotFound: true);
        m_Gameplay_Scream = m_Gameplay.FindAction("Scream", throwIfNotFound: true);
        m_Gameplay_StopGame = m_Gameplay.FindAction("StopGame", throwIfNotFound: true);
        m_Gameplay_Map = m_Gameplay.FindAction("Map", throwIfNotFound: true);
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
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MoveRight;
    private readonly InputAction m_Gameplay_MoveLeft;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_SwordAttack;
    private readonly InputAction m_Gameplay_GunShot;
    private readonly InputAction m_Gameplay_Potion;
    private readonly InputAction m_Gameplay_Save;
    private readonly InputAction m_Gameplay_SoundInfluence;
    private readonly InputAction m_Gameplay_SoundDomain;
    private readonly InputAction m_Gameplay_Scream;
    private readonly InputAction m_Gameplay_StopGame;
    private readonly InputAction m_Gameplay_Map;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveRight => m_Wrapper.m_Gameplay_MoveRight;
        public InputAction @MoveLeft => m_Wrapper.m_Gameplay_MoveLeft;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @SwordAttack => m_Wrapper.m_Gameplay_SwordAttack;
        public InputAction @GunShot => m_Wrapper.m_Gameplay_GunShot;
        public InputAction @Potion => m_Wrapper.m_Gameplay_Potion;
        public InputAction @Save => m_Wrapper.m_Gameplay_Save;
        public InputAction @SoundInfluence => m_Wrapper.m_Gameplay_SoundInfluence;
        public InputAction @SoundDomain => m_Wrapper.m_Gameplay_SoundDomain;
        public InputAction @Scream => m_Wrapper.m_Gameplay_Scream;
        public InputAction @StopGame => m_Wrapper.m_Gameplay_StopGame;
        public InputAction @Map => m_Wrapper.m_Gameplay_Map;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @SwordAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwordAttack;
                @SwordAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwordAttack;
                @SwordAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwordAttack;
                @GunShot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGunShot;
                @GunShot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGunShot;
                @GunShot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGunShot;
                @Potion.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPotion;
                @Potion.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPotion;
                @Potion.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPotion;
                @Save.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSave;
                @SoundInfluence.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoundInfluence;
                @SoundInfluence.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoundInfluence;
                @SoundInfluence.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoundInfluence;
                @SoundDomain.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoundDomain;
                @SoundDomain.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoundDomain;
                @SoundDomain.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSoundDomain;
                @Scream.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScream;
                @Scream.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScream;
                @Scream.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScream;
                @StopGame.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStopGame;
                @StopGame.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStopGame;
                @StopGame.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStopGame;
                @Map.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Map.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Map.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @SwordAttack.started += instance.OnSwordAttack;
                @SwordAttack.performed += instance.OnSwordAttack;
                @SwordAttack.canceled += instance.OnSwordAttack;
                @GunShot.started += instance.OnGunShot;
                @GunShot.performed += instance.OnGunShot;
                @GunShot.canceled += instance.OnGunShot;
                @Potion.started += instance.OnPotion;
                @Potion.performed += instance.OnPotion;
                @Potion.canceled += instance.OnPotion;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @SoundInfluence.started += instance.OnSoundInfluence;
                @SoundInfluence.performed += instance.OnSoundInfluence;
                @SoundInfluence.canceled += instance.OnSoundInfluence;
                @SoundDomain.started += instance.OnSoundDomain;
                @SoundDomain.performed += instance.OnSoundDomain;
                @SoundDomain.canceled += instance.OnSoundDomain;
                @Scream.started += instance.OnScream;
                @Scream.performed += instance.OnScream;
                @Scream.canceled += instance.OnScream;
                @StopGame.started += instance.OnStopGame;
                @StopGame.performed += instance.OnStopGame;
                @StopGame.canceled += instance.OnStopGame;
                @Map.started += instance.OnMap;
                @Map.performed += instance.OnMap;
                @Map.canceled += instance.OnMap;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSwordAttack(InputAction.CallbackContext context);
        void OnGunShot(InputAction.CallbackContext context);
        void OnPotion(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnSoundInfluence(InputAction.CallbackContext context);
        void OnSoundDomain(InputAction.CallbackContext context);
        void OnScream(InputAction.CallbackContext context);
        void OnStopGame(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
    }
}
