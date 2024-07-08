using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReptileEnemy : MonoBehaviour
{
    public float rangex;
    public float speed;
    public float attackDamage;
    public float attackRange;
    public float attackFrequency;
    public float attackSpeedUpRate;
    GameObject player;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;

        if (Mathf.Abs(distancex) < rangex)
        {
            if (Mathf.Abs(distancex) < attackRange)
            {
                player.GetComponent<Movement>().stick = true;
                player.GetComponent<Jump>().stick = true;
                this.GetComponent<ForcesOnEnemy>().resistance = 1;
                speed = 0;
            }

            if (this.GetComponent<ForcesOnEnemy>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -distancex / Mathf.Abs(distancex), this.GetComponent<ForcesOnEnemy>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -distancex / Mathf.Abs(distancex), this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
