using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpforce = 8;
    public float jumptime = 2;
    float maxspeed = 0;
    float stime = 0;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GetComponentInChildren<GroundDetection>().detected)
        {
            stime = Time.time;
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && (Time.time - stime < jumptime)) 
        {
            if (rb.velocity.y > maxspeed)
            {
                maxspeed = rb.velocity.y;
            }
            else
            {
                if (Time.time - stime > jumptime / 2) rb.velocity = new Vector2(rb.velocity.x, maxspeed * jumptime - (Time.time - stime ));
                else rb.velocity = new Vector2(rb.velocity.x, maxspeed);
            }
        }
    }
}
