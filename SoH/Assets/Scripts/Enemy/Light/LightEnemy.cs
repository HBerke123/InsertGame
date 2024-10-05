using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    public GroundDetection climbUp;
    public GroundDetection climbDown;
    public GroundDetection leftSide;
    public GroundDetection rightSide;
    public GroundDetection teleportCollider;
    public GameObject lightWave;
    public float lightUp;
    public float lightDamage;
    public float speed;
    public float runRange;
    public float moveRangeX;
    public float rangeX;
    public float shootFrequency;
    public float noticeTime;
    public float runSpeed;
    GameObject player;
    GameObject beam;
    bool running;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((Time.time - th > shootFrequency) && (th != 0) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            if ((Mathf.Abs(this.transform.position.x - player.transform.position.x) <= rangeX) && !this.GetComponent<BlocksOnObject>().isBlocked)
            {
                Shoot(Mathf.RoundToInt(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x)));
            }
            th = 0;
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;

        if (((Mathf.Abs(distancex) < moveRangeX) || this.GetComponent<Notice>().isNoticed) && (Mathf.Abs(distancex) > rangeX) && (this.GetComponent<ForcesOnObject>().Force.x == 0) && beam == null && (!running))
        {
            this.GetComponent<Notice>().noticeTime = Mathf.Max(this.GetComponent<Notice>().noticeTime, noticeTime);
            th = 0;

            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Abs(distancex) / distancex * speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Abs(distancex) / distancex * speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            
                if (climbDown.detected && !climbUp.detected)
                {
                    this.transform.position += Vector3.up / 2;
                }
            }
        }
        else if ((beam == null) && running)
        {
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distancex) / distancex * runSpeed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distancex) / distancex * runSpeed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }

            teleportCollider.transform.localPosition = Vector3.left * 2 * Mathf.Pow(distancex, 2) / distancex;

            if ((Mathf.Abs(distancex) / distancex == 1) && rightSide.detected)
            {
                if (!teleportCollider.detected)
                {
                    this.transform.position = teleportCollider.transform.position;
                }
            }
            else if ((Mathf.Abs(distancex) / distancex == -1) && leftSide.detected)
            {
                if (!teleportCollider.detected)
                {
                    this.transform.position = teleportCollider.transform.position;
                }
            }

            if (Mathf.Abs(distancex) > rangeX - runRange)
            {
                running = false;
            }
        }
        else if (beam == null)
        {
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if ((Mathf.Abs(distancex) < rangeX) && beam == null)
        {
            if (th == 0)
            {
                th = Time.time;
            }
        }

        if ((Mathf.Abs(distancex) < runRange) && beam == null)
        {
            running = true;
        }
    }

    void Shoot(int direction)
    {
        GameObject SBox = Instantiate(lightWave, this.transform.position + (lightWave.transform.localScale.x + this.transform.localScale.x) / 2 * direction * Vector3.right + Vector3.up * lightUp, Quaternion.identity);
        SBox.GetComponent<DamagePlayer>().damageAmount = lightDamage;
        beam = SBox;
    }
}