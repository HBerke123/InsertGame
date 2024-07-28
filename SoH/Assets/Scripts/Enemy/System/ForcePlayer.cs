using UnityEngine;

public class ForcePlayer : MonoBehaviour
{
    public float forceAmount;
    public int direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ForcesOnObject>().Force = new Vector2(forceAmount * direction, 0);
        }
    }
}
