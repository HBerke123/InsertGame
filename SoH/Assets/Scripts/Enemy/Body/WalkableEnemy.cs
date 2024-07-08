using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableEnemy : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float rangex;
    public float attackDamage;
    public float attackRange;
    public float attackFrequency;
    float th;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > attackFrequency) && (attackRange > Mathf.Abs(this.transform.position.x - player.transform.position.x)))
        {
            player.GetComponent<HealthDrainage>().TakeDamage(attackDamage);
            th = Time.time;
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;

        if ((Mathf.Abs(distancex) < rangex) && (attackRange * 3 / 4 < Mathf.Abs(distancex)))
        {
            if (this.GetComponent<ForcesOnEnemy>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-distancex / Mathf.Abs(distancex) * speed + this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<ForcesOnEnemy>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-distancex / Mathf.Abs(distancex) * speed + this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            if (this.GetComponent<ForcesOnEnemy>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<ForcesOnEnemy>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }

            if ((attackRange > Mathf.Abs(distancex)) && (th == 0))
            {
                th = Time.time - attackFrequency;
            }
        }
    }
}