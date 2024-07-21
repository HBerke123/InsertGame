using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject smoke;
    public GameObject bossSpear;
    public GameObject lightWave;
    public GameObject lightBox;
    public GameObject explodeHit;
    public float attackFrequency;
    public float lightTime;
    public float smokeSpeed;
    public float spearTime;
    public float dashSpeed;
    public float dashTime;
    public float lightAmount;
    public float moveFrequency;
    public float maxRightPoint;
    public float maxLeftPoint;
    public float rightPoint;
    public float leftPoint;
    public float lightWaveSpeed;
    public float bottom;
    public float flyAmount;
    public float flySpeed;
    public float flyTime;
    public int maxMove;
    public int attackAmount;
    GameObject player;
    float ath;
    float lth;
    float dth;
    float sth;
    float mth;
    bool attackRising;
    bool onSecondPhase;
    bool onThirdPhase;
    bool onAttack;
    int attackCounter;
    int attackDirection;
    int lastDirection;
    int direction;
    int moveCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetDirection();
        lastDirection = direction;
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.K))
        {
            this.GetComponent<HealthDrainageOnEnemy>().health = 200;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            this.GetComponent<HealthDrainageOnEnemy>().health = 100;
        }
    }

    private void FixedUpdate()
    {
        if ((mth != 0) && (Time.time - mth > moveFrequency) && (sth == 0) && (!onAttack) && (dth == 0) && (lth == 0) && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && (this.GetComponentInChildren<GroundDetection>().detected))
        {
            if ((this.GetComponent<HealthDrainageOnEnemy>().health <= this.GetComponent<HealthDrainageOnEnemy>().maxHealth * 25 / 100) && !onThirdPhase)
            {
                onAttack = true;
            }
            else if ((this.GetComponent<HealthDrainageOnEnemy>().health <= this.GetComponent<HealthDrainageOnEnemy>().maxHealth * 65 / 100) && !onSecondPhase)
            {
                SecondPhase();
                onSecondPhase = true;
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
        else if (onAttack)
        {
            if (this.transform.position.y > bottom + flyAmount)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (ath == 0)
                {
                    ath = Time.time;
                }
                else if (Time.time - ath > attackFrequency)
                {
                    Attack(attackDirection);

                    if (attackDirection == 0)
                    {
                        attackRising = true;
                    }
                    else if (attackDirection == 3)
                    {
                        attackRising = false;
                    }

                    if (attackRising)
                    {
                        attackDirection++;
                    }
                    else
                    {
                        attackDirection--;
                    }

                    if (attackCounter + 1 < attackAmount)
                    {
                        attackCounter++;
                    }
                    else
                    {
                        onAttack = false;
                        onThirdPhase = true;
                    }
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
                SendLight();
            }
        }
        else if (sth != 0)
        {
            if (Time.time - sth > flyTime)
            {
                Explode();
                sth = 0;
                mth = 0;
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
        else if (dth != 0)
        {
            if (Time.time - dth > dashTime + spearTime)
            {
                bossSpear.SetActive(false);
                dth = 0;
                mth = 0;
            }
            else if (Time.time - dth > dashTime)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Spear();
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
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - leftPoint);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - rightPoint);
            }
        }
        else
        {
            if (this.transform.position.x > player.transform.position.x)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - rightPoint);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - leftPoint);
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
        SetDirection();
        mth = 0;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject SBox = Instantiate(lightWave, new Vector3(this.transform.position.x, 1.5f + bottom + lightWave.transform.localScale.y / 2, 0), Quaternion.identity);
        SBox.GetComponent<Rigidbody2D>().velocity = direction * lightWaveSpeed * Vector2.right;
    }

    void SendLight()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(lightBox, new Vector3(Random.Range(maxLeftPoint, maxRightPoint), bottom + lightWave.transform.localScale.y / 2, 0), Quaternion.identity);
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
        dth = Time.time;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.right * dashSpeed * direction;
    }

    void Spear()
    {
        bossSpear.SetActive(true);
        bossSpear.transform.localScale = new Vector3(bossSpear.transform.localScale.x * direction, bossSpear.transform.localScale.y, bossSpear.transform.localScale.z);
    }

    void Smell()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject SBox = Instantiate(smoke, this.transform.position + Vector3.up * this.transform.localScale.y / 2, Quaternion.identity);
            SBox.GetComponent<Rigidbody2D>().velocity = (-1 + i * 2) * Vector2.right * smokeSpeed;
        }
    }

    void Attack(int direction)
    {
        ath = 0;
        for (int i = 0; i < 2; i++)
        {
            GameObject SBox = Instantiate(lightWave, this.transform.position, Quaternion.identity);
            SBox.transform.localRotation = Quaternion.Euler(0, 0, (i * 360) + (30 * direction) * (-1 + i * 2));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2((1 - i * 2) * Mathf.Cos(30 * direction * (-1 + i * 2) * Mathf.Deg2Rad) * lightWaveSpeed, (1 - i * 2) * Mathf.Sin(30 * direction * (-1 + i * 2) * Mathf.Deg2Rad) * lightWaveSpeed);
        }
    }
}