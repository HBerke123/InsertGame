using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public ParticleSystem groundParticles;
    public BoxCollider2D Attackhbox;
    public GroundDetection climbUp;
    public GroundDetection climbDown;
    public GroundDetection gd;
    public bool aiming;
    public bool stick;
    public float reloadTime;
    public float soundTime;
    public float speed;
    public float dspeed;
    public float stepFrequency;
    public float cost;
    public float cEDelay;
    public bool spawnParticles;
    float baseSpeed;
    float th;
    int moveDirection;
    GamepadControls gamepadControls;
    Rigidbody2D rb;
    CEDrainage ced;
    CEProduce cep;
    SpriteRenderer sr;
    SoundUse su;
    ScreamUse su2;
    Dash d;
    BlocksOnObject boo;
    Crouching c;
    SwordAttack sa;
    Potion p;
    ForcesOnObject foo;
    Animator a;
    MakeSound ms;
    GunShot gs;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        gs = this.GetComponentInChildren<GunShot>();
        ms = this.GetComponent<MakeSound>();
        gd = this.GetComponentInChildren<GroundDetection>();
        a = this.GetComponent<Animator>();
        foo = this.GetComponent<ForcesOnObject>();
        p = this.GetComponent<Potion>();
        sa = this.GetComponentInChildren<SwordAttack>();
        boo = this.GetComponent<BlocksOnObject>();
        d = this.GetComponent<Dash>();
        su2 = this.GetComponentInChildren<ScreamUse>();
        su = this.GetComponentInChildren<SoundUse>();
        sr = this.GetComponent<SpriteRenderer>();
        cep = this.GetComponent<CEProduce>();
        ced = this.GetComponent<CEDrainage>();
        c = this.GetComponent<Crouching>();
        baseSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();
        //string path = Application.dataPath + "/Saves/";
        //this.transform.position = new Vector3(float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[0]), float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[1]), 0);
    }

    private void FixedUpdate()
    {
        if (spawnParticles && (th == 0))
        {
            th = Time.time - stepFrequency;
        }

        if ((Time.time - th >= stepFrequency) && (spawnParticles))
        {
            ced.LoseCE(cost);
            cep.delayAmount = Mathf.Max(cep.delayAmount, cEDelay);
            ParticleSystem particles = Instantiate(groundParticles, this.transform.position, Quaternion.identity);

            for (int i = 1; i < cost + 1; i++)
            {
                reloadTimes.Add(Time.time + reloadTime / cost);
            }

            if (sr.flipX)
            {
                particles.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            
            th = Time.time;
        }

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

    private void Update()
    {
        if (!aiming && !su.started && !su2.screaming && !d.dashing && !stick && !boo.isBlocked && !c.changing && !sa.attacking && !p.drinking && !gs.started)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1;
            }
            else
            {
                moveDirection = 0;
            }

            if ((moveDirection == 0) && (gamepadControls.moveDirection == 0))
            {
                a.SetBool("Moving", false);
                spawnParticles = false;

                if (foo.Force.x != 0)
                {
                    if (foo.Force.y != 0)
                    {
                        rb.velocity = new Vector2(foo.Force.x, foo.Force.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(foo.Force.x, rb.velocity.y);
                    }
                }
                else
                {
                    if (foo.Force.y != 0)
                    {
                        rb.velocity = new Vector2(0, foo.Force.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, rb.velocity.y);
                    }
                }
            }
            else
            {
                if (gd.detected)
                {
                    a.SetBool("Moving", true);
                    spawnParticles = true;

                    if (speed == baseSpeed)
                    {
                        ms.AddTime(soundTime);
                    }

                    if (!climbUp.detected && climbDown.detected)
                    {
                        this.transform.position += Vector3.up / 2;
                    }
                }
                else
                {
                    a.SetBool("Moving", false);
                    spawnParticles = false;
                }

                if (foo.Force.y != 0)
                {
                    if (gamepadControls.moveDirection == 0)
                    {
                        rb.velocity = rb.velocity = new Vector2(moveDirection * speed + foo.Force.x, foo.Force.y);
                    }
                    else
                    {
                        rb.velocity = rb.velocity = new Vector2(gamepadControls.moveDirection * speed + foo.Force.x, foo.Force.y);
                    }
                }
                else
                {
                    if (gamepadControls.moveDirection == 0)
                    {
                        rb.velocity = rb.velocity = new Vector2(moveDirection * speed + foo.Force.x, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = rb.velocity = new Vector2(gamepadControls.moveDirection * speed + foo.Force.x, rb.velocity.y);
                    }
                }
            }
        }
        else if (!aiming && !su2.screaming && !stick && !c.changing && !sa.attacking && !p.drinking && !gs.started && !boo.isBlocked)
        {
            a.SetBool("Moving", false);
            rb.velocity = new Vector2(dspeed, rb.velocity.y);
            spawnParticles = false;
        }
        else if (!stick && !c.changing && !sa.attacking && !p.drinking)
        {
            a.SetBool("Moving", false);

            if (foo.Force.x != 0)
            {
                if (foo.Force.y != 0)
                {
                    rb.velocity = new Vector2(foo.Force.x, foo.Force.y);
                }
                else
                {
                    rb.velocity = new Vector2(foo.Force.x, rb.velocity.y);
                }
            }
            else
            {
                if (foo.Force.y != 0)
                {
                    rb.velocity = new Vector2(0, foo.Force.y);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }

            spawnParticles = false;
        }
        else if (!stick)
        {
            a.SetBool("Moving", false);
            rb.velocity = new Vector2(0, 0);
            spawnParticles = false;
        }
        else
        {
            a.SetBool("Moving", false);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            spawnParticles = false;
        }

        if (!Attackhbox.enabled && !gs.started && !boo.isBlocked)
        {
            if (Input.GetKey(KeyCode.A) || (gamepadControls.moveDirection == -1))
            {
                sr.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D) || (gamepadControls.moveDirection == 1))
            {
                sr.flipX = false;
            }
        }
    }
}