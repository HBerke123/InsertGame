using UnityEngine;

public class Crouching : MonoBehaviour
{
    public bool isCrouching;
    public float crouchingSpeed;
    public float crouchingAmount;
    public float crouchTime;
    bool crouched;
    float th;
    float speed;
    float colliderSizeY;
    float colliderPositionY;
    public bool changing;
    public GroundDetection gd;
    GamepadControls gamepadControls;
    Movement m;
    BoxCollider2D bc;
    CrouchingDetection cd;
    Animator a;
    GunShot gs;
    SwordAttack sa;
    SoundUse su;
    ScreamUse su2;
    Dash d;
    

    private void Start()
    {
        d = this.GetComponent<Dash>();
        su2 = this.GetComponentInChildren<ScreamUse>();
        su = this.GetComponentInChildren<SoundUse>();
        sa = this.GetComponentInChildren<SwordAttack>();
        gs = this.GetComponentInChildren<GunShot>();
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        a = this.GetComponent<Animator>();
        cd = this.GetComponentInChildren<CrouchingDetection>();
        bc = this.GetComponent<BoxCollider2D>();
        m = this.GetComponent<Movement>();
        speed = m.speed;
        colliderPositionY = this.GetComponent<BoxCollider2D>().offset.y;
        colliderSizeY = this.GetComponent<BoxCollider2D>().size.y;
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
        if ((Input.GetKeyDown(KeyCode.LeftShift) || gamepadControls.crouching) && !crouched && !d.dashing && !sa.attacking && !gs.started && !su.started && !su2.screaming && gd.detected)
        {
            Crouch();
            crouched = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || !gamepadControls.crouching)
        {
            crouched = false;
        }
    }

    public void Crouch()
    {
        if (cd.isSafe && !changing)
        {
            if (isCrouching)
            {
                a.SetBool("Crouching", false);
            }
            else
            {
                a.SetBool("Crouching", true);
            }

            changing = true;
            th = Time.time;
        }
    }
}