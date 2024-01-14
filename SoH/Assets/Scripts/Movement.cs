using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public bool moveable = true;
    public bool grounded;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (moveable) rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        else rb.velocity = new Vector2(0, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && grounded && rb.velocity.y <= jumpforce)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            grounded = false;
        }

        Vector2 location = new Vector2(transform.position.x, transform.position.y - 0.6f);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, -Vector2.up, 0.75f);

        if (hit.collider != null) grounded = true;
        else grounded = false;
    }
}