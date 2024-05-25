using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmperorBirdFly : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float flyspeed;
    bool ready = true;
    public bool replaceable = true;
    bool replacing = false;
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
            if (6 <= distancex && !replaceable && !replacing)
            {
                rb.velocity = new Vector2((player.transform.position.x - this.transform.position.x) / distancex * speed, rb.velocity.y);
            }
            else if (!replaceable && !replacing)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if ((distancex <= 8) && ready) StartCoroutine(Attack());

            if (replaceable) StartCoroutine(Replace());

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
        FireBullet(distancex / distance, distancey / distance);
        FireBullet(Mathf.Cos((Mathf.Rad2Deg * Mathf.Acos(distancex / distance) + 30) * Mathf.Deg2Rad), Mathf.Sin((Mathf.Rad2Deg * Mathf.Acos(distancex / distance) + 30) * Mathf.Deg2Rad));
        FireBullet(Mathf.Cos((Mathf.Rad2Deg * Mathf.Acos(distancex / distance) - 30) * Mathf.Deg2Rad), Mathf.Sin((Mathf.Rad2Deg * Mathf.Acos(distancex / distance) - 30) * Mathf.Deg2Rad));
        ready = true;
    }

    IEnumerator Replace()
    {
        replaceable = false;
        yield return new WaitForSeconds(15);
        replaceable = true;
        replacing = true;
        if (this.transform.position.x > player.transform.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            yield return new WaitUntil(() => (distancex > 6) && (this.transform.position.x < player.transform.position.x));
            replacing = false;
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            yield return new WaitUntil(() => (distancex > 6) && (this.transform.position.x > player.transform.position.x));
            replacing = false;
        }
    }

    public void FireBullet(float speedx, float speedy)
    {
        GameObject bullet = Instantiate(redbullet, this.transform.position, this.transform.rotation);
        if (distancex != 0)
        {
            if (distancey != 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed  * speedx * (player.transform.position.x - this.transform.position.x) / distancex, bulletspeed * speedy * (player.transform.position.y - this.transform.position.y) / distancey);
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed * speedx * (player.transform.position.x - this.transform.position.x) / distancex, 0);
            }
        }
        else
        {
            if (distancey != 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletspeed * speedy * (player.transform.position.y - this.transform.position.y) / distancey);
            }
            else
            {
                Destroy(bullet);
            }
        }
    }
}