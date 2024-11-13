using UnityEngine;

public class Crouching : MonoBehaviour
{
    public bool isCrouching;
    public float crouchingSpeed;
    public float crouchingAmount;
    public float crouchTime;
    public bool changing;

    bool crouched;
    float th;
    float speed;
    float colliderSizeY;
    float colliderPositionY;
    

    [SerializeField] GroundDetection gd;

    GamepadControls gamepadControls;
    Movement m;
    BoxCollider2D bc;
    CrouchingDetection cd;
    Animator a;
    SoundUse su;
    Dash d;

    private void Awake()
    {
        d = GetComponent<Dash>();
        su = GetComponent<SoundUse>();
        gamepadControls = GetComponent<GamepadControls>();
        a = GetComponent<Animator>();
        cd = GetComponentInChildren<CrouchingDetection>();
        bc = GetComponent<BoxCollider2D>();
        m = GetComponent<Movement>();
        speed = m.speed;
        colliderPositionY = GetComponent<BoxCollider2D>().offset.y;
        colliderSizeY = GetComponent<BoxCollider2D>().size.y;
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > crouchTime))
        {
            if (isCrouching)
            {
                isCrouching = false;
                a.SetBool("Crouching", false);
                m.speed = speed;
                bc.size = new Vector2(bc.size.x, colliderSizeY);
                bc.offset = new Vector2(bc.offset.x, colliderPositionY);
            }
            else
            {
                isCrouching = true;
                a.SetBool("Crouching", true);
                m.speed = crouchingSpeed;
                bc.size = new Vector2(bc.size.x, colliderSizeY - crouchingAmount);
                bc.offset = new Vector2(bc.offset.x, colliderPositionY - crouchingAmount / 2);
            }

            changing = false;
            th = 0;
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || gamepadControls.crouching) && !crouched && !d.dashing && !su.started && gd.detected)
        {
            Crouch();
            crouched = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || !gamepadControls.crouching) crouched = false;
    }

    public void Crouch()
    {
        if (cd.isSafe && !changing)
        {
            if (isCrouching) a.SetBool("Crouching", false);
            else a.SetBool("Crouching", true);

            changing = true;
            th = Time.time;
        }
    }
}