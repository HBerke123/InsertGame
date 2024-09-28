using UnityEngine;

public class ReptileEnemy : MonoBehaviour
{
    public GameObject hitbox;
    public GroundDetection climbUp;
    public GroundDetection climbDown;
    public float rangex;
    public float speed;
    public float attackDamage;
    public float attackRange;
    public float attackFrequency;
    public float attackSpeedUpRate;
    public float noticeTime;
    GameObject player;
    float defaultResistance;
    float defaultSpeed;
    float maxAttackFrequency;
    float th;
    float sth;

    private void Start()
    {
        maxAttackFrequency = attackFrequency;
        player = GameObject.FindGameObjectWithTag("Player");
        defaultResistance = this.GetComponent<ForcesOnObject>().resistance;
        defaultSpeed = speed;
    }

    private void FixedUpdate()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2));

        if ((th != 0) && (Time.time - th > attackFrequency) && (attackRange > Mathf.Abs(distance)) && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            player.GetComponent<HealthDrainage>().TakeDamage(attackDamage);
            th = Time.time;
        }

        if ((sth != 0) && (Time.time - sth > maxAttackFrequency) && (attackRange > Mathf.Abs(distance)))
        {
            attackFrequency -= attackSpeedUpRate;
            sth = Time.time;
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2));

        if (((distance < rangex) || this.GetComponent<Notice>().isNoticed) && !this.GetComponent<BlocksOnObject>().isBlocked)
        {
            this.GetComponent<Notice>().noticeTime = Mathf.Max(this.GetComponent<Notice>().noticeTime, noticeTime);

            if (distance < attackRange)
            {
                hitbox.SetActive(false);
                player.GetComponent<Movement>().stick = true;
                player.GetComponent<Jump>().stick = true;
                this.GetComponent<ForcesOnObject>().resistance = 1;
                speed = 0;

                if (th == 0)
                {
                    sth = Time.time;
                    th = Time.time - attackFrequency;
                }
            }
            else
            {
                hitbox.SetActive(true);
                player.GetComponent<Movement>().stick = false;
                player.GetComponent<Jump>().stick = false;
                this.GetComponent<ForcesOnObject>().resistance = defaultResistance;
                speed = defaultSpeed;
                attackFrequency = maxAttackFrequency;
                sth = 0;
                th = 0;

                if (this.GetComponent<ForcesOnObject>().Force != Vector2.zero)
                {
                    this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<ForcesOnObject>().Force;
                }
                else
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -distancex / Mathf.Abs(distancex), this.GetComponent<Rigidbody2D>().velocity.y);

                    if (climbDown.detected && !climbUp.detected)
                    {
                        this.transform.position += Vector3.up / 2;
                    }
                }
            }

        }
        else
        {
            if (this.GetComponent<ForcesOnObject>().Force != Vector2.zero)
            {
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<ForcesOnObject>().Force;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}