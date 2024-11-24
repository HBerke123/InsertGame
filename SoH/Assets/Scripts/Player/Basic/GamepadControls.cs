using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadControls : MonoBehaviour
{
    public InputAction moveRight;
    public InputAction moveLeft;
    public InputAction jumping;
    public InputAction crouching;
    public InputAction dashing;
    public InputAction soundInfluence;
    public InputAction map;
    public InputAction pause;
    public InputAction save;
    public InputAction accept;
    public InputAction back;
    public InputAction up;
    public InputAction down;
    public InputAction left;
    public InputAction right;
    public InputAction copy;

    private void Awake()
    {
        InputActionAsset controls = GetComponent<PlayerInput>().actions;
        moveRight = controls["MoveRight"];
        moveLeft = controls["MoveLeft"];
        jumping = controls["Jump"];
        crouching = controls["Crouch"];
        dashing = controls["Dash"];
        soundInfluence = controls["SoundInfluence"];
        pause = controls["StopGame"];
        copy = controls["Copy"];
        up = controls["Up"];
        down = controls["Down"];
        left = controls["Left"];
        right = controls["Right"];
        accept = controls["Accept"];
        back = controls["Back"];
    }
}