using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    public float extraMove;
    public float bottom;
    public float moveSpeed;
    public float blockTime;
    public float moveFrequency;
    public float rightPoint;
    public float leftPoint;
    public float maxRight;
    public float maxLeft;
    public float screamMaxScale;
    public float shakeTime;
    public float shakeFrequency;
    public float shakeForce;
    public float jumpForce;
    public float rushSpeed;
    public float rushTime;
    public float soundSpeed;
    public float screamTime;
    public float multiplier;
    public int maxMove;
    public GameObject rushBox;
    public GameObject soundWave;
    public GameObject screamWave;
    public GameObject bossHit;
    GameObject player;
    GameObject rushHit;
    bool readyToShake;
    bool onSecondPhase;
    bool rushing;
    bool rushingBack;
    bool hitted;
    int lastDirection;
    int direction;
    int moveCounter;
    float hitX;
    float mth;
    float scth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetDirection();
        lastDirection = direction;
    }

    private void FixedUpdate()
    {
        if (!rushing && !rushingBack && (mth != 0) && (Time.time - mth > moveFrequency) && (scth == 0))
        {
            Move();
            mth = Time.time;
        }
        else if (!rushing && !rushingBack && (mth != 0) && (scth == 0))
        {
            if ((this.transform.position.x > rightPoint) || (this.transform.position.x < leftPoint))
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }

        if (mth == 0)
        {
            mth = Time.time;
        }

        if (Time.time - scth > screamTime)
        {
            scth = 0;
        }

        if (rushing)
        {
            if (((this.transform.position.x < maxLeft + this.transform.localScale.x * 2) || (this.transform.position.x > maxRight - this.transform.localScale.x * 2)) && (rushHit != null))
            {
                rushing = false;
                GoBack();
            }

            if ((rushHit == null) && !hitted)
            {
                hitted = true;
                hitX = this.transform.position.x;
            }
            else if ((rushHit == null) && ((this.transform.position.x < hitX - extraMove) || (this.transform.position.x > hitX + extraMove)))
            {
                rushing = false;
                GoBack();
            }

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(rushSpeed * direction, this.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (rushingBack)
        {
            if ((this.transform.position.x > (Mathf.Abs(maxLeft) + Mathf.Abs(maxRight)) / 2 + maxLeft - this.transform.localScale.x / 2) && (this.transform.position.x < (Mathf.Abs(maxLeft) + Mathf.Abs(maxRight)) / 2 + maxLeft + this.transform.localScale.x / 2))
            {
                bossHit.SetActive(true);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
                Destroy(rushHit);
                rushingBack = false;
                SetDirection();
            }

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-rushSpeed * direction, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void Update()
    {
        if (moveCounter == maxMove)
        {
            if ((this.GetComponent<HealthDrainageOnEnemy>().health <= this.GetComponent<HealthDrainageOnEnemy>().maxHealth / 2) && (!onSecondPhase))
            {
                SecondPhase();
            }
            else
            {
                if (lastDirection == direction)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        SendWaves();
                    }
                    else
                    {
                        Rush();
                    }
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        Scream();
                    }
                    else
                    {
                        Jump();
                    }
                }
            }

            moveCounter = 0;
        }

        if (this.GetComponentInChildren<GroundDetection>().detected && readyToShake)
        {
            readyToShake = false;
            Camera.main.GetComponent<CameraShake>().StartShake(shakeFrequency, shakeTime, shakeForce);
            
            if (player.GetComponentInChildren<GroundDetection>().detected)
            {
                player.GetComponent<BlocksOnObject>().blockTime = Mathf.Max(player.GetComponent<BlocksOnObject>().blockTime, blockTime);
            }
        }

        if ((this.GetComponent<Rigidbody2D>().velocity.y > 0.1) && !this.GetComponentInChildren<GroundDetection>().detected)
        {
            readyToShake = true;
        }
    }

    void Move()
    {
        moveCounter++;

        if (Random.Range(0, 2) == 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void SendWaves()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject SBox = Instantiate(soundWave, new Vector3(this.transform.position.x + this.transform.localScale.x / 2 * direction, bottom + soundWave.transform.localScale.y / 2, 0), Quaternion.identity);
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * soundSpeed, 0);
        SBox.GetComponent<ForcePlayer>().direction = direction;
        SetDirection();
    }

    void Scream()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        scth = Time.time;
        Camera.main.GetComponent<CameraShake>().StartShake(shakeFrequency, shakeTime, shakeForce);
        Instantiate(screamWave, this.transform.position, Quaternion.identity);
        SetDirection();
    }

    void SetDirection()
    {
        lastDirection = direction;
        if (this.transform.position.x > player.transform.position.x)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    void Rush()
    {
        GameObject Sbox = Instantiate(rushBox, this.transform);
        hitted = false;
        bossHit.SetActive(false);
        rushHit = Sbox;
        Sbox.transform.localPosition = Vector3.down * 0.25f;
        rushing = true;
    }

    void GoBack()
    {
        if (rushHit != null)
        {
            Destroy(rushHit);
        }
        
        GameObject Sbox = Instantiate(rushBox, this.transform);
        bossHit.SetActive(false);
        rushHit = Sbox;
        Sbox.transform.localPosition = Vector3.down * 0.25f;
        rushingBack = true;
    }

    void Jump()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        SetDirection();
    }

    void SecondPhase()
    {
        onSecondPhase = true;
        shakeForce *= multiplier;
        rushSpeed *= multiplier;
        rushTime /= multiplier;
        soundSpeed *= multiplier;
        Scream();
    }
}