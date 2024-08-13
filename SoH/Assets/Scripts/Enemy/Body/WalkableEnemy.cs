using UnityEngine;

public class WalkableEnemy : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float rangex;
    public float attackDamage;
    public float attackRange;
    public float attackFrequency;
    public float noticeTime;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        float distancey = this.transform.position.y - player.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        if ((th != 0) && (Time.time - th > attackFrequency) && (attackRange > distance) && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            player.GetComponent<HealthDrainage>().TakeDamage(attackDamage);
            th = Time.time;
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        float distancey = this.transform.position.y - player.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));

        if (((Mathf.Abs(distancex) < rangex) || this.GetComponent<Notice>().isNoticed) && (attackRange < Mathf.Abs(distance)))
        {
            this.GetComponent<Notice>().noticeTime = Mathf.Max(this.GetComponent<Notice>().noticeTime, noticeTime);

            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-distancex / Mathf.Abs(distancex) * speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-distancex / Mathf.Abs(distancex) * speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }

            if ((attackRange > distance) && (th == 0))
            {
                th = Time.time - attackFrequency;
            }
        }
    }
}