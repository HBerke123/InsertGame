using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public ParticleSystem groundParticles;
    public BoxCollider2D Attackhbox;
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
    Rigidbody2D rb;
    float baseSpeed;
    float th;

    private void Start()
    {
        baseSpeed = speed;
        rb = this.GetComponent<Rigidbody2D>();
        string path = Application.dataPath + "/Saves/";
        this.transform.position = new Vector3(float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[0]), float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[1]), 0);
    }

    private void FixedUpdate()
    {
        if (spawnParticles && (th == 0))
        {
            th = Time.time - stepFrequency;
        }

        if ((Time.time - th >= stepFrequency) && (spawnParticles))
        {
            this.GetComponent<CEDrainage>().LoseCE(cost);
            this.GetComponent<CEProduce>().delayAmount = Mathf.Max(this.GetComponent<CEProduce>().delayAmount, cEDelay);
            ParticleSystem particles = Instantiate(groundParticles, this.transform.position, Quaternion.identity);

            for (int i = 1; i < cost + 1; i++)
            {
                reloadTimes.Add(Time.time + reloadTime / cost);
            }

            if (this.GetComponent<SpriteRenderer>().flipX)
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

                if (this.GetComponent<CEDrainage>().cE < this.GetComponent<CEDrainage>().maxCE / 2)
                {
                    this.GetComponent<CEDrainage>().GainCE(1);
                }
            }
        }
    }

    private void Update()

    {
        if (!aiming && !this.GetComponentInChildren<ScreamUse>().screaming && !this.GetComponent<Dash>().dashing && !stick && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed + this.GetComponent<ForcesOnObject>().Force.x, rb.velocity.y + this.GetComponent<ForcesOnObject>().Force.y);

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                this.GetComponent<Animator>().SetBool("Moving", false);
                spawnParticles = false;
            }
            else
            {
                if (this.GetComponentInChildren<GroundDetection>().detected)
                {
                    this.GetComponent<Animator>().SetBool("Moving", true);
                    spawnParticles = true;

                    if (speed == baseSpeed)
                    {
                        this.GetComponent<MakeSound>().AddTime(soundTime);
                    }
                }
                else
                {
                    this.GetComponent<Animator>().SetBool("Moving", false);
                    spawnParticles = false;
                }
            }
        }
        else if (!aiming && !this.GetComponentInChildren<ScreamUse>().screaming && !stick)
        {
            this.GetComponent<Animator>().SetBool("Moving", false);
            rb.velocity = new Vector2(dspeed, rb.velocity.y);
            spawnParticles = false;
        }
        else if (!stick)
        {
            this.GetComponent<Animator>().SetBool("Moving", false);

            if (this.GetComponent<ForcesOnObject>().Force.x != 0)
            {
                if (this.GetComponent<ForcesOnObject>().Force.y != 0)
                {
                    rb.velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
                }
                else
                {
                    rb.velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, rb.velocity.y);
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, this.GetComponent<ForcesOnObject>().Force.y);
            }

            rb.velocity = this.GetComponent<ForcesOnObject>().Force;
            spawnParticles = false;
        }
        else
        {
            this.GetComponent<Animator>().SetBool("Moving", false);
            rb.velocity = new Vector2(0, 0);
            spawnParticles = false;
        }

        if ((Input.GetAxisRaw("Horizontal") != 0) && !Attackhbox.enabled && !this.GetComponentInChildren<GunShot>().started)
        {
            this.GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") != 1;
        }
    }
}