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
    float maxAttackFrequency;
    float th;
    float sth;

    private void Start()
    {
        maxAttackFrequency = attackFrequency;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > attackFrequency) && (attackRange > Mathf.Abs(this.transform.position.x - player.transform.position.x)))
        {
            player.GetComponent<HealthDrainage>().TakeDamage(attackDamage);
            th = Time.time;
        }

        if ((sth != 0) && (Time.time - sth > maxAttackFrequency) && (attackRange > Mathf.Abs(this.transform.position.x - player.transform.position.x)))
        {
            attackFrequency -= attackSpeedUpRate;
            sth = Time.time;
        }
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
                this.GetComponent<ForcesOnObject>().resistance = 1;
                speed = 0;
                if (th == 0)
                {
                    sth = Time.time;
                    th = Time.time - attackFrequency;
                }
            }

            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -distancex / Mathf.Abs(distancex), this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -distancex / Mathf.Abs(distancex), this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
