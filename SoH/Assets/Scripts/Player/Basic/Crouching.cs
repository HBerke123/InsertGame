using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    public float crouchingSpeed;
    public float crouchingAmount;
    float speed;
    float colliderSizeY;
    float colliderPositionY;

    private void Start()
    {
        speed = this.GetComponent<Movement>().speed;
        colliderPositionY = this.GetComponent<BoxCollider2D>().offset.y;
        colliderSizeY = this.GetComponent<BoxCollider2D>().size.y;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.GetComponent<Movement>().speed = crouchingSpeed;
            this.GetComponent<BoxCollider2D>().size = new Vector2(this.GetComponent<BoxCollider2D>().size.x, colliderSizeY - crouchingAmount);
            this.GetComponent<BoxCollider2D>().offset = new Vector2(this.GetComponent<BoxCollider2D>().offset.x, colliderPositionY - crouchingAmount / 2);
        }
        else
        {
            this.GetComponent<Movement>().speed = speed;
            this.GetComponent<BoxCollider2D>().size = new Vector2(this.GetComponent<BoxCollider2D>().size.x, colliderSizeY);
            this.GetComponent<BoxCollider2D>().offset = new Vector2(this.GetComponent<BoxCollider2D>().offset.x, colliderPositionY);
        }
    }
}
