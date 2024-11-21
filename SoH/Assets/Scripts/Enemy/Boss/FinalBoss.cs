using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject bossPhaseLight;
    public GameObject smoke;
    public GameObject bossSpear;
    public GameObject lightWave;
    public GameObject lightBox;
    public GameObject explodeHit;
    public float attackTime;
    public float lightTime;
    public float smokeSpeed;
    public float spearTime;
    public float lightAmount;
    public float dashSpeed;
    public float moveFrequency;
    public float maxRightPoint;
    public float maxLeftPoint;
    public float rightPoint;
    public float leftPoint;
    public float bottom;
    public float top;
    public float flyAmount;
    public float flySpeed;
    public float flyTime;
    public float lightUp;
    public int maxMove;
    GameObject player;
    GameObject Light;
    float ath;
    float lth;
    float sth;
    float mth;
    float ssth;
    bool goRight;
    bool onSecondPhase;
    bool onThirdPhase;
    bool onAttack;
    bool lighted;
    bool dashing;
    int lastDirection;
    int direction;
    int moveCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetDirection();
        lastDirection = direction;
    }

    private void FixedUpdate()
    {
        if ((mth != 0) && (Time.time - mth > moveFrequency) && (sth == 0) && (!onAttack) && !dashing && (lth == 0) && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && this.GetComponentInChildren<GroundDetection>().detected && (Light == null))
        {
            if ((this.GetComponent<HealthDrainageOnEnemy>().health <= this.GetComponent<HealthDrainageOnEnemy>().maxHealth * 25 / 100) && !onThirdPhase)
            {
                onAttack = true;
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            else if ((this.GetComponent<HealthDrainageOnEnemy>().health <= this.GetComponent<HealthDrainageOnEnemy>().maxHealth * 65 / 100) && !onSecondPhase)
            {
                SecondPhase();
                onSecondPhase = true;
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            else
            {
                if (moveCounter >= maxMove)
                {
                    if (onSecondPhase)
                    {
                        if (Random.Range(0, 4) == 0)
                        {
                            SendWave();
                        }
                        else if (Random.Range(0, 3) == 0)
                        {
                            Dash();
                        }
                        else if (Random.Range(0, 2) == 0)
                        {
                            Smell();
                        }
                        else
                        {
                            lth = Time.time;
                        }
                    }
                    else
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            SendWave();
                        }
                        else
                        {
                            lth = Time.time;
                        }
                    }

                    moveCounter = 0;
                }
                else
                {
                    Move();
                }
            }
        }
        else if ((mth != 0) && (Time.time - mth < moveFrequency) && (sth == 0) && (!onAttack) && !dashing && (lth == 0) && this.GetComponentInChildren<GroundDetection>().detected && (Light == null))
        {
            if (goRight)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - rightPoint) + this.GetComponent<ForcesOnObject>().Force;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - leftPoint) + this.GetComponent<ForcesOnObject>().Force;
            }
        }
        else if (onAttack)
        {
            if (this.transform.position.y > bottom + flyAmount)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                if (ath == 0)
                {
                    Attack();
                }
                else if (Time.time - ath > attackTime)
                {
                    this.GetComponent<Rigidbody2D>().gravityScale = 1;
                    onAttack = false;
                    onThirdPhase = true;
                }
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
            }
        }
        else if (mth == 0)
        {
            mth = Time.time;
        }
        else if (lth != 0)
        {
            if (Time.time - lth > lightTime)
            {
                SendLight(maxLeftPoint, maxRightPoint);
            }
        }
        else if (sth != 0)
        {
            if (Time.time - sth > flyTime)
            {
                Explode();
                sth = 0;
                mth = 0;
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else
            {
                if (this.transform.position.y > bottom + flyAmount)
                {
                    this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                else
                {
                    this.GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
                }
            }
        }
        else if (dashing)
        {
            if ((this.transform.position.x >= maxRightPoint - this.transform.localScale.x / 2 - bossSpear.transform.lossyScale.x) || (this.transform.position.x <= maxLeftPoint + this.transform.localScale.x / 2 + bossSpear.transform.lossyScale.x))
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                if (!lighted)
                {
                    ssth = Time.time;
                    if (direction == 1)
                    {
                        SendLight(maxLeftPoint, maxRightPoint - this.transform.localScale.x - bossSpear.transform.lossyScale.x);
                    }
                    else
                    {
                        SendLight(maxLeftPoint + this.transform.localScale.x + bossSpear.transform.lossyScale.x, maxRightPoint);
                    }

                    lighted = true;
                }

                Spear();

                if (Time.time - ssth > spearTime)
                {
                    dashing = false;
                    bossSpear.SetActive(false);
                }
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = dashSpeed * direction * Vector2.right;
            }
        }
    }

    void Move()
    {
        mth = 0;
        moveCounter++;
        if (lastDirection == direction)
        {
            if (Random.Range(0, 2) == 0)
            {
                goRight = false;
            }
            else
            {
                goRight = true;
            }
        }
        else
        {
            if (this.transform.position.x > player.transform.position.x)
            {
                goRight = true;
            }
            else
            {
                goRight = false;
            }
        }
    }

    void SetDirection()
    {
        lastDirection = direction;
        if (player.transform.position.x > this.transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    void SendWave()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SetDirection();
        mth = 0;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject SBox = Instantiate(lightWave, new Vector3(this.transform.position.x + lightWave.transform.localScale.x / 2, lightUp + bottom + lightWave.GetComponent<BossLight>().bigScale / 2, 0), Quaternion.identity);
        Light = SBox;
    }

    void SendLight(float maxLeft, float maxRight)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        for (int i = 0; i < 3; i++)
        {
            int num = 0;
            GameObject Sbox;

            if (onSecondPhase)
            {
                num = Random.Range(0, 2);
            }

            if (num == 0)
            {
                Sbox = Instantiate(lightBox, new Vector3(Random.Range(maxLeft + (Mathf.Abs(maxLeft) + Mathf.Abs(maxRight)) / 3 * i, maxLeft + (Mathf.Abs(maxLeft) + Mathf.Abs(maxRight)) / 3 * (i + 1)), bottom + lightBox.transform.localScale.y / 2, 0), Quaternion.identity);
            }
            else
            {
                Sbox = Instantiate(lightBox, new Vector3(Random.Range(maxLeft + (Mathf.Abs(maxLeft) + Mathf.Abs(maxRight)) / 3 * i, maxLeft + (Mathf.Abs(maxLeft) + Mathf.Abs(maxRight)) / 3 * (i + 1)), top - lightBox.transform.localScale.y / 2, 0), Quaternion.identity);
            }

            Sbox.GetComponent<BossLight>().num = num;
        }

        lth = 0;
    }

    void SecondPhase()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
        sth = Time.time;
    }

    void Explode()
    {
        Instantiate(explodeHit, this.transform.position, Quaternion.identity);
    }

    void Dash()
    {
        SetDirection();
        dashing = true;
        lighted = false;
        this.GetComponent<Rigidbody2D>().velocity = dashSpeed * direction * Vector2.right;
    }

    void Spear()
    {
        bossSpear.SetActive(true);
        bossSpear.transform.localPosition = new Vector3(Mathf.Abs(bossSpear.transform.localPosition.x) * direction, bossSpear.transform.localPosition.y, bossSpear.transform.localPosition.z);
    }

    void Smell()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        for (int i = 0; i < 2; i++)
        {
            GameObject SBox = Instantiate(smoke, this.transform.position + Vector3.up * this.transform.localScale.y / 2, Quaternion.identity);
            SBox.GetComponent<Rigidbody2D>().velocity = (-1 + i * 2) * smokeSpeed * Vector2.right;
        }
    }

    void Attack()
    {
        ath = Time.time;
        for (int i = 0; i < 2; i++)
        {
            GameObject SBox = Instantiate(bossPhaseLight, this.transform.position, Quaternion.identity);
            SBox.GetComponent<PhaseLight>().num = i;
            SBox.GetComponent<PhaseLight>().boss = this.gameObject;
        }
    }
}