using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public BoxCollider2D Attackhbox;
    public bool stick;
    public float speed = 5;
    public float sspeed = 5;
    public float dspeed;
    float pspeed = 0;
    float aspeed = 0;
    float lspeed = 0;
    public bool movable = true;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (movable)
        {
            pspeed = Input.GetAxisRaw("Horizontal") * speed;
        }

        if ((pspeed != 0) && (pspeed != lspeed) && movable && !stick)
        {
            if (lspeed == 0) aspeed = rb.velocity.x;
            else aspeed = rb.velocity.x - lspeed;
            
            rb.velocity = new Vector2(aspeed + pspeed, rb.velocity.y);
        }
        else if (movable && !stick)
        {
            aspeed = rb.velocity.x - pspeed;
            if (aspeed != 0) aspeed -= aspeed * (sspeed / 10);

            rb.velocity = new Vector2(aspeed + pspeed, rb.velocity.y);
        }
        else if (!stick)
        {
            aspeed = rb.velocity.x - pspeed;
            if (aspeed != 0) aspeed -= aspeed * (sspeed / 10);

            rb.velocity = new Vector2(aspeed + dspeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if ((pspeed != 0) && !Attackhbox.enabled) this.GetComponent<SpriteRenderer>().flipX = pspeed / Mathf.Abs(pspeed) != 1;

        lspeed = pspeed;
    }
}