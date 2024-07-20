using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject lightWave;
    public GameObject lightBox;
    public float lightFrequency;
    public float lightAmount;
    public float moveFrequency;
    public float rightPoint;
    public float leftPoint;
    public float lightWaveSpeed;
    public float lightSpeed;
    public float bottom;
    public float flySpeed;
    public float flyTime;
    public int maxMove;
    GameObject player;
    float sth;
    float lth;
    float mth;
    bool isSecondPhase;
    int lastDirection;
    int direction;
    int moveCounter;
    int lightCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetDirection();
        lastDirection = direction;
    }

    private void FixedUpdate()
    {
        if ((mth != 0) && (Time.time - mth > moveFrequency) && (lth == 0) && (sth == 0) && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            if ((this.GetComponent<HealthDrainageOnEnemy>().health <= this.GetComponent<HealthDrainageOnEnemy>().maxHealth * 65 / 100) && !isSecondPhase)
            {
                SecondPhase();
                isSecondPhase = true;
            }
            else
            {
                if (moveCounter >= maxMove)
                {
                    if (direction == lastDirection)
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
        else if (mth == 0)
        {
            mth = Time.time;
        }
        else if ((lth != 0) && (Time.time - lth > lightFrequency))
        {
            if (lightAmount > lightCounter)
            {
                SendLight();
            }
            else
            {
                lightCounter = 0;
                lth = 0;
                mth = 0;
                SetDirection();
            }
        }
        else if (sth != 0)
        {
            if (Time.time - sth > flyTime)
            {
                sth = 0;
                mth = 0;
            }
        }
    }

    void Move()
    {
        mth = 0;
        moveCounter++;
        if (Random.Range(0, 2) == 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - leftPoint);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.left * (this.transform.position.x - rightPoint);
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
        mth = 0;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject SBox = Instantiate(lightWave, new Vector3(this.transform.position.x, 1.5f + bottom + lightWave.transform.localScale.y / 2, 0), Quaternion.identity);
        SBox.GetComponent<Rigidbody2D>().velocity = direction * lightWaveSpeed * Vector2.right;
        SetDirection();
    }

    void SendLight()
    {
        lightCounter++;
        lth = Time.time;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        for (int i = 0; i < 2; i++)
        {
            GameObject SBox = Instantiate(lightBox, new Vector3(this.transform.position.x, bottom + lightBox.transform.localScale.y / 2, 0), Quaternion.identity);
            SBox.GetComponent<Rigidbody2D>().velocity = (-1 + i * 2) * lightSpeed * Vector2.right;
        }
    }

    void SecondPhase()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
        sth = Time.time;
    }
}