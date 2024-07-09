using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D Attackhbox;
    public bool dashing;
    public bool stick;
    public float speed = 5;
    public float sspeed = 5;
    public float dspeed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        string path = Application.dataPath + "/Saves/";
        this.transform.position = new Vector3(float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[0]), float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[3].Split(" ")[1]), 0);
    }

    private void Update()
    {
        if (!dashing && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        }
        else if (!stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            rb.velocity = new Vector2(dspeed, rb.velocity.y);
        }
        else if (!stick)
        {
            rb.velocity = this.GetComponent<ForcesOnObject>().Force;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
        if ((Input.GetAxisRaw("Horizontal") != 0) && !Attackhbox.enabled) this.GetComponent<SpriteRenderer>().flipX = Input.GetAxisRaw("Horizontal") != 1;
    }
}