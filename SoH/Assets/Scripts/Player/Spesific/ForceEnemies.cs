using UnityEngine;

public class ForceEnemies : MonoBehaviour
{
    public int direction;
    public float forcePower;
    public bool destroyOnTouch;
    public GameObject arrow;

    public void Force(GameObject enemy)
    {
        if (direction == 0)
        {
            enemy.GetComponent<ForcesOnObject>().Force = new Vector2(0, forcePower);
        }
        else if (direction == 1)
        {
            enemy.GetComponent<ForcesOnObject>().Force = new Vector2(forcePower, 0);
        }
        else if (direction == 2)
        {
            enemy.GetComponent<ForcesOnObject>().Force = new Vector2(0, -forcePower);
        }
        else if (direction == 3)
        {
            enemy.GetComponent<ForcesOnObject>().Force = new Vector2(-forcePower, 0);
        }
        else
        {
            arrow.transform.LookAt(enemy.transform);
            if (arrow.transform.localRotation.eulerAngles.y == 90)
            {
                if (arrow.transform.localRotation.eulerAngles.x > 180)
                {
                    enemy.GetComponent<ForcesOnObject>().Force = new Vector2(Mathf.Cos(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower, Mathf.Sin(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower);
                }
                else
                {
                    enemy.GetComponent<ForcesOnObject>().Force = new Vector2(Mathf.Cos(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower, -Mathf.Sin(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower);
                }
            }
            else
            {
                if (arrow.transform.localRotation.eulerAngles.x > 180)
                {
                    enemy.GetComponent<ForcesOnObject>().Force = new Vector2(-Mathf.Cos(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower, Mathf.Sin(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower);
                }
                else
                {
                    enemy.GetComponent<ForcesOnObject>().Force = new Vector2(-Mathf.Cos(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower, -Mathf.Sin(arrow.transform.localRotation.eulerAngles.x * Mathf.Deg2Rad) * forcePower);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Force(collision.gameObject);
            if (destroyOnTouch)
            {
                Destroy(this.gameObject);
            }
        }
        else if (collision.CompareTag("EnemySound"))
        {
            if (this.CompareTag("Sound"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
        else if (collision.CompareTag("EnemyScream"))
        {
            if (this.CompareTag("Scream"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}