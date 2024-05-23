using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmperorBirdFly : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;

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
        float distancey = Mathf.Abs(this.transform.position.x - player.transform.position.x);
        float distancex = Mathf.Abs(this.transform.position.y - player.transform.position.y);
    }
}
