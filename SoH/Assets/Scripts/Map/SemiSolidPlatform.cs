using UnityEngine;

public class SemiSolidPlatform : MonoBehaviour
{
    Collider2D Player;
    Collider2D c;

    private void Awake()
    {
        c = GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!c.IsTouching(Player) && (c.bounds.max.y > Player.bounds.min.y))
        {
            c.isTrigger = true;
        }
        else if (c.bounds.max.y < Player.bounds.min.y)
        {
            c.isTrigger = false;
        }
    }
}
