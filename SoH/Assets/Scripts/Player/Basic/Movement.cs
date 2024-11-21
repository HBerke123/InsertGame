using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    readonly List<float> reloadTimes = new();

    [SerializeField] List<AudioClip> steps = new();
    [SerializeField] ParticleSystem groundParticles;
    [SerializeField] GroundDetection climbUpR;
    [SerializeField] GroundDetection climbUpL;
    [SerializeField] GroundDetection climbDownR;
    [SerializeField] GroundDetection climbDownL;
    [SerializeField] GroundDetection gd;

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
    public GameObject riding;

    bool pressedLeft;
    bool pressedRight;
    float baseSpeed;
    float th;
    int moveDirection;
    int counter;
    GamepadControls gamepadControls;
    Rigidbody2D rb;
    CEDrainage ced;
    CEProduce cep;
    SpriteRenderer sr;
    SoundUse su;
    Dash d;
    BlocksOnObject boo;
    Crouching c;
    ForcesOnObject foo;
    Animator a;
    MakeSound ms;

    private void Start()
    {
        gamepadControls = GetComponent<GamepadControls>();
        ms = GetComponent<MakeSound>();
        gd = GetComponentInChildren<GroundDetection>();
        a = GetComponent<Animator>();
        foo = GetComponent<ForcesOnObject>();
        boo = GetComponent<BlocksOnObject>();
        d = GetComponent<Dash>();
        su = GetComponent<SoundUse>();
        sr = GetComponent<SpriteRenderer>();
        cep = GetComponent<CEProduce>();
        ced = GetComponent<CEDrainage>();
        c = GetComponent<Crouching>();
        rb = GetComponent<Rigidbody2D>();
        baseSpeed = speed;

        //string path = Application.dataPath + "/Saves/";
        //this.transform.position = new Vector3(float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[0]), float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[1]), 0);
    }

    private void FixedUpdate()
    {
        if (spawnParticles && (th == 0)) th = Time.time - stepFrequency;

        if ((Time.time - th >= stepFrequency) && spawnParticles)
        {
            ced.LoseCE(cost);
            cep.delayAmount = Mathf.Max(cep.delayAmount, cEDelay);
            ParticleSystem particles = Instantiate(groundParticles, transform.position, Quaternion.identity);

            if (counter == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(steps[Random.Range(0, 50)]);
                counter = 0;
            }
            else counter++;
            
            for (int i = 1; i < cost + 1; i++) reloadTimes.Add(Time.time + reloadTime / cost);

            if (sr.flipX) particles.gameObject.transform.localScale = new Vector3(-1, 1, 1);

            th = Time.time;
        }

        for (int i = 0; i < reloadTimes.Count; i++)
        {
            if (Time.time > reloadTimes[i])
            {
                reloadTimes.RemoveAt(i);

                if (ced.cE < ced.maxCE / 2) ced.GainCE(1);
            }
        }
    }

    private void Update()
    {
        if (gamepadControls.moveRight.IsPressed() && !pressedRight)
        {
            moveDirection = 1;
            pressedRight = true;
        }
        else if (gamepadControls.moveLeft.IsPressed() && !pressedLeft)
        {
            moveDirection = -1;
            pressedLeft = true;
        }
        else if (!gamepadControls.moveLeft.IsPressed() && !gamepadControls.moveRight.IsPressed()) moveDirection = 0;

        if (!gamepadControls.moveRight.IsPressed())
        {
            if (gamepadControls.moveLeft.IsPressed()) moveDirection = -1;

            pressedRight = false;
        }

        if (!gamepadControls.moveLeft.IsPressed())
        {
            if (gamepadControls.moveRight.IsPressed()) moveDirection = 1;

            pressedLeft = false;
        }

        if (!aiming && !su.started && !d.dashing && !stick && !boo.isBlocked && !c.changing)
        {
            if (moveDirection == 0)
            {
                a.SetBool("Moving", false);
                spawnParticles = false;

                if (foo.Force.x != 0)
                {
                    if (foo.Force.y != 0) rb.velocity = new(foo.Force.x, foo.Force.y);
                    else rb.velocity = new(foo.Force.x, rb.velocity.y);
                }
                else if (foo.Force.y != 0) rb.velocity = Vector2.up * foo.Force.y;
                else
                {
                    rb.velocity = Vector2.up * rb.velocity.y;

                    if (gd.grounds.Contains(riding)) rb.velocity = riding.GetComponentInChildren<Rigidbody2D>().velocity;
                }
            }
            else
            {
                if ((gd.detected || GetComponentInChildren<PlatformDetection>().detected) && (Mathf.Round(rb.velocity.y) == 0))
                {
                    a.SetBool("Moving", true);
                    spawnParticles = true;

                    if (speed == baseSpeed) ms.AddTime(soundTime);

                    if ((moveDirection == 1) && !climbUpR.detected && climbDownR.detected && climbDownR.climbable) transform.position += Vector3.up / 2;
                    else if ((moveDirection == -1) && !climbUpL.detected && climbDownL.detected && climbDownL.climbable) transform.position += Vector3.up / 2;
                }
                else
                {
                    a.SetBool("Moving", false);
                    spawnParticles = false;
                }

                if (foo.Force.y != 0) rb.velocity = rb.velocity = new Vector2(moveDirection * speed + foo.Force.x, foo.Force.y);
                else rb.velocity = rb.velocity = new Vector2(moveDirection * speed + foo.Force.x, rb.velocity.y);
            }
        }
        else if (!aiming && !stick && !c.changing && !boo.isBlocked)
        {
            a.SetBool("Moving", false);
            rb.velocity = new (dspeed, rb.velocity.y);
            spawnParticles = false;
        }
        else if (!stick && !c.changing)
        {
            a.SetBool("Moving", false);

            if (foo.Force.x != 0)
            {
                if (foo.Force.y != 0) rb.velocity = new(foo.Force.x, foo.Force.y);
                else rb.velocity = new(foo.Force.x, rb.velocity.y);
            }
            else
            {
                if (foo.Force.y != 0) rb.velocity = Vector2.up * foo.Force.y;
                else rb.velocity = Vector2.up * rb.velocity.y;
            }

            spawnParticles = false;
        }
        else if (!stick)
        {
            a.SetBool("Moving", false);
            rb.velocity = Vector2.zero;
            spawnParticles = false;
        }
        else
        {
            a.SetBool("Moving", false);
            rb.velocity = new(rb.velocity.x, rb.velocity.y);
            spawnParticles = false;
        }

        if (!boo.isBlocked)
        {
            if (moveDirection == -1) sr.flipX = true;
            else if (moveDirection == 1) sr.flipX = false;
        }
    }
}