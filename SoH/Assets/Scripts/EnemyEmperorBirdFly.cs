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
    public GameObject arrow;
    public float distancey;
    public float distancex;

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
        arrow.transform.LookAt(player.transform.position);
        arrow.transform.rotation = Quaternion.Euler(0, 0, -arrow.transform.rotation.eulerAngles.x);
        ready = false;
        yield return new WaitForSeconds(5);
        ready = true;
    }
}