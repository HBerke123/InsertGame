using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmperorBirdFly : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float flyspeed;
    bool ready = true;
    GameObject player;
    public GameObject redbullet;
    public GameObject bluebullet;
    public float bulletspeed = 1;
    public float distancey;
    public float distancex;
    public float distance;

    private void Start()
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

    private void Update()
    {
        distancex = Mathf.Abs(this.transform.position.x - player.transform.position.x);
        distancey = Mathf.Abs(this.transform.position.y - player.transform.position.y);
        distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
        
        if ((distancex < 12) && (distancey < 12))
        {
            if ((6 <= distancex))
            {
                rb.velocity = new Vector2((player.transform.position.x - this.transform.position.x) / distancex * speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if ((distancex <= 8) && ready)
            {
                StartCoroutine(Attack());
            }

            if (distancey <= 5)
            {
                rb.velocity = new Vector2(rb.velocity.x, flyspeed);
                flyspeed = 7 - distancey;
            }
            else if (distancey <= 6)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    IEnumerator Attack()
    {
        ready = false;
        yield return new WaitForSeconds(5);
        for (int i = 0; i < 3; i++) {
            GameObject bullet = Instantiate(redbullet, this.transform.position, this.transform.rotation);
            if (distancex != 0)
            {
                if (distancey != 0)
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed * (distancex / distance * (player.transform.position.x - this.transform.position.x) / distancex + Mathf.Sqrt(3) / 2 * (i - 1)), bulletspeed * (distancey / distance * (player.transform.position.y - this.transform.position.y) / distancey + 0.5f * (i - 1)));
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed * (distancex / distance * (player.transform.position.x - this.transform.position.x) / distancex + Mathf.Sqrt(3) / 2 * (i - 1)), 0);
                }
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , bulletspeed * (distancey / distance * (player.transform.position.y - this.transform.position.y) / distancey + 0.5f * (i - 1)));
            }
        }

        ready = true;
    }
}