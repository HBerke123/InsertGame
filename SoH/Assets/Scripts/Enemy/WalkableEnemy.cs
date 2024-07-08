using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableEnemy : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float rangex;
    public float attackrange;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;

        if ((Mathf.Abs(distancex) < rangex) && (attackrange < Mathf.Abs(distancex)))
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
        }
    }
}