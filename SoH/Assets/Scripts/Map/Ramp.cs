using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    public int direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sound"))
        {
            Vector2 soundDirection;

            if (collision.GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                soundDirection = Vector2.up * collision.GetComponent<Rigidbody2D>().velocity.y / Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                soundDirection = Vector2.right * collision.GetComponent<Rigidbody2D>().velocity.x / Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.x);
            }

            if (soundDirection.x == 0)
            {
                if (soundDirection.y == 1)
                {
                    if (direction == 1)
                    {
                        soundDirection = Vector2.right;
                    }
                    else if (direction == 2)
                    {
                        soundDirection = Vector2.left;
                    }
                }
                else
                {
                    if (direction == 0)
                    {
                        soundDirection = Vector2.right;
                    }
                    else if (direction == 3)
                    {
                        soundDirection = Vector2.left;
                    }
                }
            }
            else 
            {
                if (soundDirection.x == 1)
                {
                    if (direction == 2)
                    {
                        soundDirection = Vector2.down;
                    }
                    else if (direction == 3)
                    {
                        soundDirection = Vector2.up;
                    }
                }
                else
                {
                    if (direction == 0)
                    {
                        soundDirection = Vector2.up;
                    }
                    else if (direction == 1)
                    {
                        soundDirection = Vector2.down;
                    }
                }
            }

            if ((soundDirection == Vector2.up) || (soundDirection == Vector2.down))
            {
                collision.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                collision.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            collision.GetComponent<Rigidbody2D>().velocity = soundDirection * (Mathf.Abs(collision.GetComponent<Rigidbody2D>().velocity.x) + collision.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
