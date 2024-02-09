using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public float jumpforce = 6.25f;
    public bool grounded;
    public float distance;
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
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.y - player.transform.position.y), 2));
        if (distance <= 8)
        {
            if (player.transform.position.x < this.transform.position.x) rb.AddForce(-speed * Vector2.right);
            else if (player.transform.position.x > this.transform.position.x) rb.AddForce(-speed * Vector2.left);
        }

        Vector2 location = new Vector3(transform.position.x - 0.50f, transform.position.y - 0.75f, 0);
        RaycastHit2D hit = Physics2D.Raycast(location, Vector2.right, 1);

        if (hit.collider != null) grounded = true;
        else grounded = false;
    }
}
