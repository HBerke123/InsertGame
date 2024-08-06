using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadControls : MonoBehaviour
{
    PlayerControls controls;
    public Vector2 gunDirection;
    public int moveDirection;
    public bool jumping;
    public bool crouching;
    public bool dashing;
    public bool screaming;
    public bool soundDomain;
    public bool soundInfluence;
    public bool potion;
    public bool swordAttack;
    public bool gunShot;
    public bool map;
    public bool pause;
    public bool save;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.MoveRight.performed += ctx => moveDirection = 1;
        controls.Gameplay.MoveLeft.performed += ctx => moveDirection = -1;
        controls.Gameplay.Jump.performed += ctx => jumping = true;
        controls.Gameplay.Crouch.performed += ctx => crouching = true;
        controls.Gameplay.Dash.performed += ctx => dashing = true;
        controls.Gameplay.Scream.performed += ctx => screaming = true;
        controls.Gameplay.SoundDomain.performed += ctx => soundDomain = true;
        controls.Gameplay.SoundInfluence.performed += ctx => soundInfluence = true;
        controls.Gameplay.Potion.performed += ctx => potion = true;
        controls.Gameplay.SwordAttack.performed += ctx => swordAttack = true;
        controls.Gameplay.GunShot.performed += ctx => gunShot = true;
        controls.Gameplay.Map.performed += ctx => map = true;
        controls.Gameplay.StopGame.performed += ctx => pause = true;
        controls.Gameplay.Save.performed += ctx => save = true;
        controls.Gameplay.Save.performed += ctx => SetDirection(ctx.ReadValue<Vector2>());
        controls.Gameplay.MoveRight.canceled += ctx => ResetMovement(1);
        controls.Gameplay.MoveLeft.canceled += ctx => ResetMovement(-1);
        controls.Gameplay.Jump.canceled += ctx => jumping = false;
        controls.Gameplay.Crouch.canceled += ctx => crouching = false;
        controls.Gameplay.Dash.canceled += ctx => dashing = false;
        controls.Gameplay.Scream.performed += ctx => screaming = false;
        controls.Gameplay.SoundDomain.canceled += ctx => soundDomain = false;
        controls.Gameplay.SoundInfluence.canceled += ctx => soundInfluence = false;
        controls.Gameplay.Potion.canceled += ctx => potion = false;
        controls.Gameplay.SwordAttack.canceled += ctx => swordAttack = false;
        controls.Gameplay.GunShot.canceled += ctx => gunShot = false;
        controls.Gameplay.Map.canceled += ctx => map = false;
        controls.Gameplay.StopGame.canceled += ctx => pause = false;
        controls.Gameplay.Save.canceled += ctx => save = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void ResetMovement(int direction)
    {
        if (moveDirection == direction)
        {
            moveDirection = 0;
        }
    }

    private void SetDirection(Vector2 direction)
    {
        float total = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        gunDirection = new Vector2(direction.x / total, direction.y / total);
    }
}