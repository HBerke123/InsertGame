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
    float timePressed = 0f;
    public float agilityFactor = 5;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (moveable) rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        else rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded && rb.velocity.y <= jumpforce)
        {
            timePressed = Time.time;
            rb.AddForce(Vector2.up * jumpforce * agilityFactor / 4, ForceMode2D.Impulse);
            grounded = false;
        }

        if (Input.GetKeyUp(KeyCode.Space) && grounded && rb.velocity.y <= jumpforce)
        {
            timePressed = Time.time - timePressed;
            if (timePressed < 1)
            {
                rb.AddForce(Vector2.up * jumpforce * agilityFactor / 4, ForceMode2D.Impulse);
                grounded = false;
            }
            else if (timePressed >= 5)
            {
                rb.AddForce(Vector2.up * jumpforce * 1.5f * Mathf.Sqrt(5) / 4, ForceMode2D.Impulse);
                grounded = false;
            }
            else
            {
                rb.AddForce(Vector2.up * jumpforce * 1.5f * Mathf.Sqrt(timePressed) * agilityFactor / 4, ForceMode2D.Impulse);
                grounded = false;
            }
        }

        Vector2 location = new Vector3(transform.position.x - 0.50f, transform.position.y - 0.75f, 0);
        RaycastHit2D hit = Physics2D.Raycast(location, Vector2.right, 1);

        if (hit.collider != null) grounded = true;
        else grounded = false;
    }
}