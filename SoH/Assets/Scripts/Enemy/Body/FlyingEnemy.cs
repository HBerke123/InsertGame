using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject arrow;
    public GameObject Thorn;
    public float thornDamage;
    public float flySpeed;
    public float followRange;
    public float stopRange;
    public float followSpeed;
    public float rangex;
    public float rangeY;
    public float cooldown;
    public float thornSpeed;
    public float yPos;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown) && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            th = 0;
            ThrowThorn();
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;

        if (this.transform.position.y < yPos)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, flySpeed + this.GetComponent<ForcesOnObject>().Force.y);
        }
        else if (this.transform.position.y > yPos + rangeY)
        {
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }

            this.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else
        {
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
            }

            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if (Mathf.Abs(distancex) < followRange)
        {
            if (this.GetComponent<ForcesOnObject>().Force.x == 0)
            {
                if ((Mathf.Abs(distancex) < followRange) && (stopRange < Mathf.Abs(distancex)))
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(-distancex / Mathf.Abs(distancex) * followSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
                }
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }

            if ((Mathf.Abs(distancex) < rangex) && (th == 0))
            {
                th = Time.time;
            }
        }
        else
        {
            if (this.GetComponent<ForcesOnObject>().Force.x == 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }

            th = 0;
        }
    }

    void ThrowThorn()
    {
        GameObject SThorn = Instantiate(Thorn, this.transform.position, Quaternion.identity);
        float distancex = player.transform.position.x - this.transform.position.x;
        float distancey = player.transform.position.y - this.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
        SThorn.GetComponent<Rigidbody2D>().velocity = new Vector2(distancex / distance * thornSpeed, distancey / distance * thornSpeed);
        SThorn.transform.LookAt(player.transform);

        if (SThorn.transform.localRotation.eulerAngles.y < 180)
        {
            SThorn.transform.rotation = Quaternion.Euler(0, 0, -SThorn.transform.localRotation.eulerAngles.x - 90);
        }
        else
        {
            SThorn.transform.rotation = Quaternion.Euler(0, 0, SThorn.transform.localRotation.eulerAngles.x + 90);
        }
        
        SThorn.GetComponent<DamagePlayer>().damageAmount = thornDamage;
    }
}