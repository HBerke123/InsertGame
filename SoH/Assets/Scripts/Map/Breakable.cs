using UnityEngine;

public class Breakable : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Break()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        float distance = this.GetComponent<BoxCollider2D>().Distance(player.GetComponent<BoxCollider2D>()).distance;

        if (player.GetComponent<Dash>().dashing && (distance < 4))
        {
            Break();
        }
    }
}