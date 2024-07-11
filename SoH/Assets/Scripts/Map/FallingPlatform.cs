using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private readonly float fallDelay = 1f;
    private float timeHolder = 0f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
        if (Time.time - timeHolder >= 2)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector3(94.9f, -1.1f, 0f);
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        timeHolder = Time.time;
        

    }
    public void Update()
    {
        if (Time.time - timeHolder >= 2)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            
            transform.position = new Vector3(94.9f, -1.1f, 0f);
        }
    }
}
