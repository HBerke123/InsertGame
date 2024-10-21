using UnityEngine;

public class ForceEnemies : MonoBehaviour
{
    public bool soundForce;
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
            float distancex = enemy.transform.position.x - transform.position.x;
            float distancey = enemy.transform.rotation.y - transform.rotation.y;
            float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
            enemy.GetComponent<ForcesOnObject>().Force = new Vector2(distancex / distance, distancey / distance) * forcePower;
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
        else if (collision.CompareTag("Domain"))
        {
            Force(collision.gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            if ((collision.GetComponent<SoundBreakable>() != null) && soundForce)
            {
                collision.GetComponent<SoundBreakable>().Break();
            }
            else if ((collision.GetComponent<SoundLever>() != null) && soundForce)
            {
                collision.GetComponent<SoundLever>().ChangeStatment();
            }
        }
    }
}