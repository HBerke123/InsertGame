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
        float distancex = this.transform.position.x - player.transform.position.x;
        float distancey = this.transform.position.y - player.transform.position.y + player.transform.lossyScale.y / 2;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        if (player.GetComponent<Dash>().dashing && (distance < 4))
        {
            Break();
        }
    }
}