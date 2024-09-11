using UnityEngine;

public class ForcePlayer : MonoBehaviour
{
    public float forceAmount;
    public int direction;
    public bool weakToDash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !(weakToDash && collision.GetComponent<Dash>().dashing) && !collision.GetComponent<HealthDrainage>().isInvisible)
        {
            if (direction == 0)
            {
                collision.GetComponent<ForcesOnObject>().Force = new Vector2(collision.GetComponent<ForcesOnObject>().Force.x, forceAmount);
            }
            else if (direction == 2)
            {
                collision.GetComponent<ForcesOnObject>().Force = new Vector2(collision.GetComponent<ForcesOnObject>().Force.x, -forceAmount);
            }
            else if (direction == 4)
            {
                float distancey = collision.transform.position.x - this.transform.position.x;
                float distancex = collision.transform.position.y - this.transform.position.y;
                float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
                collision.GetComponent<ForcesOnObject>().Force = new Vector2(distancex / distance, distancey / distance) * forceAmount;
            }
            else
            {
                collision.GetComponent<ForcesOnObject>().Force = new Vector2(forceAmount * direction, collision.GetComponent<ForcesOnObject>().Force.y);
            }
        }
    }
}