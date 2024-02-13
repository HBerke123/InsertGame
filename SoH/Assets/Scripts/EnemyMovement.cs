using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public float jumpforce = 6.25f;
    public bool grounded;
    public float distancex;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        foreach (GameObject gameObject in FindObjectsOfType<GameObject>()) {
            if (gameObject.CompareTag("Player"))
            {
                player = gameObject;
                break;
            }
        }
    }

    private void Update()
    {
        distancex = this.transform.position.x - player.transform.position.x;

        if ((-8 <= distancex) && (distancex <= 8))
        {
            if (distancex < 1 && distancex > -1) distancex = distancex / Mathf.Abs(distancex);
            rb.velocity = new Vector2(-distancex, rb.velocity.y);
        }

        Vector2 location = new Vector3(transform.position.x - 0.50f, transform.position.y - 0.75f, 0);
        RaycastHit2D hit = Physics2D.Raycast(location, Vector2.right, 1);

        if (hit.collider != null) grounded = true;
        else grounded = false;
    }
}
