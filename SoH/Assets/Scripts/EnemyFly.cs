using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    public float distancex;
    public float distancey;
    public float speed = 10;
    public float flyspeed;
    public float attackspeed = 1;
    bool attacking = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        foreach (GameObject gameObject in FindObjectsOfType<GameObject>())
        {
            if (gameObject.CompareTag("Player"))
            {
                player = gameObject;
                break;
            }
        }
    }

    void Update()
    {
        distancey = Mathf.Abs(this.transform.position.y - player.transform.position.y);
        distancex = Mathf.Abs(this.transform.position.x - player.transform.position.x);
        if ((3 <= distancex) && (distancex <= 12))
        {
            rb.velocity = new Vector2((player.transform.position.x - this.transform.position.x) / distancex * speed, rb.velocity.y);
        }
        else
        {
            if (attacking && (0.5f <= distancex))
            {
                rb.velocity = new Vector2((player.transform.position.x - this.transform.position.x) / distancex * speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            
        }

        if ((5 >= distancey) && !attacking)
        {
            rb.velocity = new Vector2(rb.velocity.x, flyspeed);
            flyspeed = 7 - distancey;
            attacking = false;
        }
        else if (((5 < distancey) || (attacking)) && (0.5f < distancey)) {
            rb.velocity = new Vector2(rb.velocity.x, -attackspeed);
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }
}
