using UnityEngine;

public class BadSmellingFlower : MonoBehaviour
{
    GameObject player;
    public GameObject badSmoke;
    public float range;
    public float cooldown;
    float distance;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown) && (distance <= range))
        {
            Smell();
            th = Time.time;
        }
    }

    private void Update()
    {
        distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.y - player.transform.position.y), 2));
        if ((distance <= range) && (th == 0))
        {
            th = Time.time - cooldown;
        }
    }

    public void Smell()
    {
        Instantiate(badSmoke, this.transform.position, new Quaternion(0, 0, 0, 0));
    }
}