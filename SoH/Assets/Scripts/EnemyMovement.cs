using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.y - player.transform.position.y), 2));
        if (distance <= 4)
        {
            if (player.transform.position.x > this.transform.position.x) rb.velocity = new Vector2(speed, rb.velocity.y);
            else rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
}
