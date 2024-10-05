using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class Portal : MonoBehaviour
{
    readonly List<GameObject> portalObjects = new();
    public GameObject destination;
    public int direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!portalObjects.Contains(collision.gameObject) && (collision.CompareTag("Player") || collision.CompareTag("Sound")))
        {
            destination.GetComponent<Portal>().portalObjects.Add(collision.gameObject);
            collision.transform.position = destination.transform.position;

            if (collision.CompareTag("Sound"))
            {
                if (direction == 0)
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                    }
                    else if (destination.GetComponent<Portal>().direction == 3)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                    }
                }
                else if (direction == 1)
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, 0);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                }
                else if (direction == 2)
                {
                    if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 3)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                    }
                }
                else
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else if (destination.GetComponent<Portal>().direction == 3)
                    {
                        collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, 0);
                    }
                }
            }
            else
            {
                if (direction == 0)
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, -collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                }
                else if (direction == 1)
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                }
                else if (direction == 2)
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, -collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, -collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                    }
                }
                else
                {
                    if (destination.GetComponent<Portal>().direction == 0)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 1)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else if (destination.GetComponent<Portal>().direction == 2)
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sound"))
        {
            portalObjects.Remove(collision.gameObject);
        }
    }
}