using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Movement : MonoBehaviour
{
    public ParticleSystem groundParticles;
    public BoxCollider2D Attackhbox;
    public bool aiming;
    public bool screaming;
    public bool dashing;
    public bool stick;
    public float soundTime;
    public float speed;
    public float dspeed;
    public float particleFrequency;
    Rigidbody2D rb;
    public bool spawnParticles;
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
            th = Time.time - particleFrequency;
        }

        if ((Time.time - th >= particleFrequency) && (spawnParticles))
        {       
            ParticleSystem particles = Instantiate(groundParticles, this.transform.position, new Quaternion(0, 0, 0, 0));
            if (this.GetComponent<SpriteRenderer>().flipX)
            {
                particles.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            th = Time.time;
        }
    }

    private void Update()

    {
        if (!aiming && !screaming && !dashing && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

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
        else if (!aiming && !screaming && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            this.GetComponent<Animator>().SetBool("Moving", false);
            rb.velocity = new Vector2(dspeed, rb.velocity.y);
            spawnParticles = false;
        }
        else if (!aiming && !screaming && !stick)
        {
            this.GetComponent<Animator>().SetBool("Moving", false);
            rb.velocity = this.GetComponent<ForcesOnObject>().Force;
            spawnParticles = false;
        }
        else
        {
            this.GetComponent<Animator>().SetBool("Moving", false);
            rb.velocity = new Vector2(0, 0);
            spawnParticles = false;
        }

        if ((Input.GetAxisRaw("Horizontal") != 0) && !Attackhbox.enabled)
        {
            this.GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") != 1;
        }
    }
}