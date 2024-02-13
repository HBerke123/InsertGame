using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public float slideforce;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rb.velocity.x >= 8)
            {
                rb.AddForce(Vector2.right * slideforce);
            }
            else if (rb.velocity.x <= -8)
            {
                rb.AddForce(Vector2.left * slideforce);
            }
        }
    }
}
