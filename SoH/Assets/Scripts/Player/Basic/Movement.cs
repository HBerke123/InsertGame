using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Movement : MonoBehaviour
{
    public ParticleSystem groundParticles;
    public BoxCollider2D Attackhbox;
    public bool dashing;
    public bool stick;
    public float speed = 5;
    public float sspeed = 5;
    public float dspeed;
    public float particleFrequency;
    Rigidbody2D rb;
    bool spawnParticles;
    float th;

    private void Start()
    {
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
            ParticleSystem particles = Instantiate(groundParticles, this.transform.position - new Vector3(0, 1, 0), new Quaternion(0, 0, 0, 0));
            if (this.GetComponent<SpriteRenderer>().flipX)
            {
                particles.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            th = Time.time;
        }
    }

    private void Update()
    {
        if (!dashing && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
            if ((Input.GetAxisRaw("Horizontal") != 0) && (this.GetComponentInChildren<GroundDetection>().detected))
            {
                spawnParticles = true;
            }
            else
            {
                spawnParticles = false;
            }
        }
        else if (!stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            rb.velocity = new Vector2(dspeed, rb.velocity.y);
            spawnParticles = false;
        }
        else if (!stick)
        {
            rb.velocity = this.GetComponent<ForcesOnObject>().Force;
            spawnParticles = false;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            spawnParticles = false;
        }
        
        if ((Input.GetAxisRaw("Horizontal") != 0) && !Attackhbox.enabled) this.GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") != 1;
    }
}