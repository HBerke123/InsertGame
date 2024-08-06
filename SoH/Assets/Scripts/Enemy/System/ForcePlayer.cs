using UnityEngine;

public class ForcePlayer : MonoBehaviour
{
    public float forceAmount;
    public int direction;
    public bool weakToDash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !(weakToDash && collision.GetComponent<Dash>().dashing))
        {
            collision.GetComponent<ForcesOnObject>().Force = new Vector2(forceAmount * direction, 0);
        }
    }
}
