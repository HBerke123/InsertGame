using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public BoxCollider2D Attackhbox;
    public bool dashing;
    public bool stick;
    public float speed = 5;
    public float sspeed = 5;
    public float dspeed;
    float pspeed = 0;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!dashing && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            rb.velocity = new Vector2(pspeed = Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
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
        
        if ((pspeed != 0) && !Attackhbox.enabled) this.GetComponent<SpriteRenderer>().flipX = pspeed / Mathf.Abs(pspeed) != 1;
    }
}