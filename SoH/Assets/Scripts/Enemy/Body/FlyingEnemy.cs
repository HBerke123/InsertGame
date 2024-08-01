using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject Thorn;
    public float thornDamage;
    public float flySpeed;
    public float followRange;
    public float stopRange;
    public float followSpeed;
    public float rangex;
    public float rangeY;
    public float thornSpeed;
    public float yPos;
    public float angleBetween;
    public float attackFrequency;
    public float waitTime;
    public float noticeTime;
    public int attackAmount;
    int attackCounter;
    float wth;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((wth == 0) && (th != 0) && (Time.time - th > attackFrequency) && (attackCounter < attackAmount))
        {
            for (int i = 0; i < 4; i++)
            {
                ThrowThorn(i);
            }

            attackCounter++;
            th = Time.time;
        }
        else if ((wth == 0) && (th != 0) && (Time.time - th > attackFrequency))
        {
            wth = Time.time;
        }
        else if ((wth != 0) && (Time.time - wth > waitTime))
        {
            wth = 0;
            attackCounter = 0;
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

        if ((Mathf.Abs(distancex) < followRange) || this.GetComponent<Notice>().isNoticed)
        {
            this.GetComponent<Notice>().noticeTime = Mathf.Max(this.GetComponent<Notice>().noticeTime, noticeTime);
            if ((th == 0) && (wth == 0))
            {
                th = Time.time;
            }

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
        }
        else
        {
            if (Mathf.Abs(distancex) < rangex)
            {
                if ((th == 0) && (wth == 0))
                {
                    th = Time.time;
                }
            }

            if (this.GetComponent<ForcesOnObject>().Force.x == 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    void ThrowThorn(float direction)
    {
        GameObject SThorn = Instantiate(Thorn, this.transform.position, Quaternion.identity);
        float distancex = player.transform.position.x - this.transform.position.x;
        float distancey = player.transform.position.y - this.transform.position.y + player.transform.localScale.y / 2;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
        float angle = Mathf.Acos(distancex / distance) * Mathf.Rad2Deg + angleBetween * (-1.5f + direction);
        SThorn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(distancex / Mathf.Abs(distancex) * angle * Mathf.Deg2Rad), distancey / Mathf.Abs(distancey) * Mathf.Sin(angle * Mathf.Deg2Rad)) * thornSpeed;
        SThorn.transform.LookAt(player.transform);

        if (SThorn.transform.localRotation.eulerAngles.y < 180)
        {
            SThorn.transform.rotation = Quaternion.Euler(0, 0, -SThorn.transform.localRotation.eulerAngles.x - 90 - angleBetween * (-1.5f + direction));
        }
        else
        {
            SThorn.transform.rotation = Quaternion.Euler(0, 0, SThorn.transform.localRotation.eulerAngles.x + 90 - angleBetween * (-1.5f + direction));
        }
        
        SThorn.GetComponent<DamagePlayer>().damageAmount = thornDamage;
    }
}