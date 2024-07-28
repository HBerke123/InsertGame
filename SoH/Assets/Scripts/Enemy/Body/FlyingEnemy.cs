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
        if ((th != 0) && (Time.time - th > cooldown) && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
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
        arrow.transform.LookAt(player.transform);
        GameObject SThorn = Instantiate(Thorn, this.transform.position, new Quaternion(0, 0, 0, 0));

        if (arrow.transform.rotation.eulerAngles.y == 270)
        {
            SThorn.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Cos(arrow.transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * thornSpeed, -Mathf.Sin(arrow.transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * thornSpeed);
            SThorn.transform.rotation = Quaternion.Euler(0, 0, arrow.transform.rotation.eulerAngles.x + 90);
        }
        else
        {
            SThorn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(arrow.transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * thornSpeed, -Mathf.Sin(arrow.transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * thornSpeed);
            SThorn.transform.rotation = Quaternion.Euler(0, 0, -arrow.transform.rotation.eulerAngles.x - 90);
        }
        SThorn.GetComponent<DamagePlayer>().damageAmount = thornDamage;
    }
}