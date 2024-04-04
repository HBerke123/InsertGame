using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    public float distance;
    public float speed = 10;

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
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.y - player.transform.position.y), 2));
        if ((3 <= distance) && (distance <= 12))
        {
            rb.velocity = new Vector2((player.transform.position.x - this.transform.position.x) / Mathf.Abs(player.transform.position.x - this.transform.position.x) * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
