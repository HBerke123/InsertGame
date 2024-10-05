using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public float damage;
    public float speed;
    public float attackSpeed;
    public BoxCollider2D hitbox;
    float startY;
    bool attacked;
    bool attacking;
    bool hitted;

    private void Start()
    {
        startY = this.transform.position.y;
    }

    private void Update()
    {
        if ((this.GetComponentInChildren<PlayerDetection>().detected || attacking) && !attacked && !this.GetComponentInChildren<GroundDetection>().detected)
        {
            attacking = true;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.down * attackSpeed;
        }
        else
        {
            attacking = false;

            if (this.transform.position.y < startY)
            {
                attacked = true;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            }
            else
            {
                hitted = false;
                attacked = false;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }

        if (!hitted && hitbox.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>()))
        {
            hitted = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CheckpointRecorder>().LoadCheckpoint();
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDrainage>().TakeDamage(damage);
        }
    }
}