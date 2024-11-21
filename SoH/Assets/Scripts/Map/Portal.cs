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
            
            switch (destination.GetComponent<Portal>().direction)
            {
                case 0:
                    collision.transform.position = collision.transform.position + Vector3.up / 2;
                    break;
                case 1:
                    collision.transform.position = collision.transform.position + Vector3.right / 2;
                    break;
                case 2:
                    collision.transform.position = collision.transform.position + Vector3.down / 2;
                    break;
                case 3:
                    collision.transform.position = collision.transform.position + Vector3.left / 2;
                    break;
            }

            if (collision.CompareTag("Sound"))
            {
                switch (direction) 
                {
                    case 0:
                        if (direction == 0)
                        {
                            switch (destination.GetComponent<Portal>().direction)
                            {
                                case 0:
                                    collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.y);
                                    break;
                                case 1:
                                    collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                                    break;
                                case 3:
                                    collision.GetComponent<Rigidbody2D>().velocity = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                                    break;
                            }
                        }
                        break;
                    case 1:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 1:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, 0);
                                break;
                            case 2:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                        }
                        break;
                    case 2:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 1:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                                break;
                            case 2:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, 0);
                                break;
                        }
                        break;
                    case 3:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 2:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 3:
                                collision.GetComponent<Rigidbody2D>().velocity = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, 0);
                                break;
                        }
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case 0:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, -collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                        }
                        break;
                    case 1:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                        }
                        break;
                    case 2:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, -collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.y, -collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                        }
                        break;
                    case 3:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new Vector3(-collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                        }
                        break;
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