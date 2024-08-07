using UnityEngine;
using System.Collections.Generic;

public class Jump : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public MenuOpener menuOpener;
    public bool screaming;
    public bool stick;
    public float soundTime;
    public float jumpforce;
    public float jumptime;
    public float cEDelay;
    public float cost;
    public float reloadTime;
    bool jumping;
    bool jumped;
    float maxspeed;
    float stime;
    GamepadControls gamepadControls;
    Rigidbody2D rb;
    CEDrainage ced;
    GroundDetection gd;
    ForcesOnObject foo;
    CrouchingDetection cd;
    CEProduce cep;
    MakeSound mk;
    Crouching c;
    Animator a;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        rb = this.GetComponent<Rigidbody2D>();
        ced = this.GetComponent<CEDrainage>();
        gd = this.GetComponentInChildren<GroundDetection>();
        foo = this.GetComponent<ForcesOnObject>();
        cd = this.GetComponentInChildren<CrouchingDetection>();
        cep = this.GetComponent<CEProduce>();
        mk = this.GetComponent<MakeSound>();
        c = this.GetComponent<Crouching>();
        a = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < reloadTimes.Count; i++)
        {
            if (Time.time > reloadTimes[i]) 
            {
                reloadTimes.RemoveAt(i);

                if (ced.cE < ced.maxCE / 2)
                {
                    ced.GainCE(1);
                }
            }
        }
    }

    void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            a.SetBool("Grounded", gd.detected);

            if ((Input.GetKey(KeyCode.Space) || gamepadControls.jumping) && gd.detected && !stick && (foo.Force == Vector2.zero) && !c.isCrouching && !jumping && !jumped)
            {
                jumped = true;
                jumping = true;
                a.SetBool("Jumping", true);
                ced.LoseCE(cost);
                mk.AddTime(soundTime);
                cep.delayAmount = Mathf.Max(cep.delayAmount, cEDelay);
                stime = Time.time;
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

                for (int i = 1; i < cost + 1; i++)
                {
                    reloadTimes.Add(Time.time + reloadTime / cost * i);
                }
            }
            else if ((Input.GetKey(KeyCode.Space) || gamepadControls.jumping) && gd.detected && !stick && (foo.Force == Vector2.zero) && !jumping && !jumped)
            {
                c.Crouch();
            }
            else if ((Input.GetKey(KeyCode.Space) || gamepadControls.jumping) && (Time.time - stime < jumptime) && !stick && !screaming)
            {
                if (rb.velocity.y > maxspeed)
                {
                    maxspeed = rb.velocity.y;
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, maxspeed * jumptime - (Time.time - stime));
                }
            }
            else if (!Input.GetKey(KeyCode.Space) || !gamepadControls.jumping || (Time.time - stime > jumptime))
            {
                a.SetBool("Jumping", false);
                jumping = false;
            }

            if ((!Input.GetKey(KeyCode.Space) || !gamepadControls.jumping) && gd.detected)
            {
                jumped = false;
            }
        }
    }
}