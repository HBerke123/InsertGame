using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    readonly List<GameObject> portalObjects = new();

    public List<GameObject> points = new();
    public GameObject destination;
    public int direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!portalObjects.Contains(collision.gameObject) && (collision.CompareTag("Player") || collision.CompareTag("Sound")))
        {
            destination.GetComponent<Portal>().portalObjects.Add(collision.gameObject);
            

            if (collision.CompareTag("Sound"))
            {
                Vector2 vel = collision.GetComponent<Rigidbody2D>().velocity;
                float min = float.PositiveInfinity;
                int num = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (Mathf.Sqrt(Mathf.Pow(points[i].transform.position.x - collision.transform.position.x, 2) + Mathf.Pow(points[i].transform.position.y - collision.transform.position.y, 2)) < min)
                    {
                        min = Mathf.Sqrt(Mathf.Pow(points[i].transform.position.x - collision.transform.position.x, 2) + Mathf.Pow(points[i].transform.position.y - collision.transform.position.y, 2));
                        num = i;
                    }
                }

                collision.transform.position = destination.GetComponent<Portal>().points[num].transform.position;

                switch (destination.GetComponent<Portal>().direction)
                {
                    case 0:
                        collision.transform.position += Vector3.up / 2;
                        break;
                    case 1:
                        collision.transform.position += Vector3.right / 2;
                        break;
                    case 2:
                        collision.transform.position += Vector3.down / 2;
                        break;
                    case 3:
                        collision.transform.position += Vector3.left / 2;
                        break;
                }

                switch (direction)
                {
                    case 0:
                        if (direction == 0)
                        {
                            switch (destination.GetComponent<Portal>().direction)
                            {
                                case 0:
                                    collision.GetComponent<Rigidbody2D>().velocity = vel.y * Vector2.down;
                                    break;
                                case 1:
                                    collision.GetComponent<Rigidbody2D>().velocity = vel.y * Vector2.left;
                                    break;
                                case 3:
                                    collision.GetComponent<Rigidbody2D>().velocity = vel.y * Vector2.right;
                                    break;
                            }
                        }
                        break;
                    case 1:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.x * Vector2.down;
                                break;
                            case 1:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.x * Vector2.left;
                                break;
                            case 2:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.x * Vector2.up;
                                break;
                        }
                        break;
                    case 2:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 1:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.y * Vector2.right;
                                break;
                            case 2:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.y * Vector2.down;
                                break;
                            case 3:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.y * Vector2.left;
                                break;
                        }
                        break;
                    case 3:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.x * Vector2.up;
                                break;
                            case 2:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.x * Vector2.down;
                                break;
                            case 3:
                                collision.GetComponent<Rigidbody2D>().velocity = vel.x * Vector2.left;
                                break;
                        }
                        break;
                }

                collision.GetComponent<ForceEnemies>().direction = destination.GetComponent<Portal>().direction;

                if (collision.GetComponent<Rigidbody2D>().velocity.y == 0) collision.transform.rotation = Quaternion.identity;
                else if (collision.GetComponent<Rigidbody2D>().velocity.x == 0) collision.transform.rotation = new(0, 0, Mathf.Sqrt(50), Mathf.Sqrt(50));
            }
            else
            {
                collision.transform.position = destination.transform.position;

                switch (destination.GetComponent<Portal>().direction)
                {
                    case 0:
                        collision.transform.position += Vector3.up / 2;
                        break;
                    case 1:
                        collision.transform.position += Vector3.right / 2;
                        break;
                    case 2:
                        collision.transform.position += Vector3.down / 2;
                        break;
                    case 3:
                        collision.transform.position += Vector3.left / 2;
                        break;
                }

                switch (direction)
                {
                    case 0:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, -collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new(-collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                        }
                        break;
                    case 1:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new(-collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                        }
                        break;
                    case 2:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, -collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.y, -collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new(-collision.GetComponent<Rigidbody2D>().velocity.y, collision.GetComponent<Rigidbody2D>().velocity.x);
                                break;
                        }
                        break;
                    case 3:
                        switch (destination.GetComponent<Portal>().direction)
                        {
                            case 0:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 1:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 2:
                                collision.GetComponent<ForcesOnObject>().Force = new(collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                            case 3:
                                collision.GetComponent<ForcesOnObject>().Force = new(-collision.GetComponent<Rigidbody2D>().velocity.x, collision.GetComponent<Rigidbody2D>().velocity.y);
                                break;
                        }
                        break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sound")) portalObjects.Remove(collision.gameObject);
    }
}