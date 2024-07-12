using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    public float moveFrequency;
    public float rightPoint;
    public float leftPoint;
    public float screamMaxScale;
    public float shakeTime;
    public float shakeFrquency;
    public float shakeForce;
    public float jumpForce;
    public float rushSpeed;
    public float rushTime;
    public float soundSpeed;
    public float soundTime;
    public float screamTime;
    public int maxMove;
    public GameObject soundWave;
    public GameObject screamWave;
    GameObject player;
    bool readyToShake;
    int lastDirection;
    int direction;
    int moveCounter;
    float lastRandom;
    float mth;
    float rth;
    float rrth;
    float sth;
    float ssth;
    float scth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetDirection();
        lastDirection = direction;
    }

    private void FixedUpdate()
    {
        if ((ssth != 0) && (Time.time - ssth < shakeTime))
        {
            if (sth == 0)
            {
                sth = Time.time - shakeFrquency;
            }
            else if ((sth != 0) && (Time.time - sth > shakeFrquency))
            {
                Shake();
                sth = Time.time;
            }
        }
        else
        {
            Camera.main.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if ((rth == 0) && (rrth == 0) && (mth != 0) && (Time.time - mth > moveFrequency) && (scth == 0))
        {
            Move();
            mth = Time.time;
        }

        if (mth == 0)
        {
            mth = Time.time;
        }

        if (Time.time - scth > screamTime)
        {
            scth = 0;
        }

        if ((rth != 0) && (Time.time - rth >= rushTime))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            rth = 0;
            GoBack();
        }
        else if (rth != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(rushSpeed * direction, this.GetComponent<Rigidbody2D>().velocity.y);
        }

        if ((rrth != 0) && (Time.time - rrth >= rushTime))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            rrth = 0;
            SetDirection();
        }
        else if (rrth != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-rushSpeed * direction, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void Update()
    {
        if (moveCounter == maxMove)
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

            moveCounter = 0;
        }

        if (this.GetComponentInChildren<GroundDetection>().detected && readyToShake)
        {
            readyToShake = false;
            ssth = Time.time;
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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - leftPoint), this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - rightPoint), this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void SendWaves()
    {
        GameObject SBox = Instantiate(soundWave, this.transform.position, Quaternion.identity);
        SBox.GetComponent<SkillEnd>().TotalTime = soundTime;
        
        if (direction == 1)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(soundSpeed, 0);
        }
        else
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-soundSpeed, 0);
        }

        SetDirection();
    }

    void Scream()
    {
        scth = Time.time;
        ssth = Time.time;
        GameObject SBox = Instantiate(screamWave, this.transform.position, Quaternion.identity);
        SBox.GetComponent<SkillEnd>().TotalTime = screamTime;
        SBox.GetComponent<GrowingProjectile>().TotalTime = screamTime;
        SBox.GetComponent<GrowingProjectile>().minyscale = 0;
        SBox.GetComponent<GrowingProjectile>().maxyscale = screamMaxScale;
        SBox.GetComponent<GrowingProjectile>().minxscale = 0;
        SBox.GetComponent<GrowingProjectile>().maxxscale = screamMaxScale;
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
        rth = Time.time;
    }

    void GoBack()
    {
        rrth = Time.time;
    }

    void Jump()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        SetDirection();
    }

    void Shake()
    {
        float randomPos;

        if (Random.Range(0, 2) == 0)
        {
            randomPos = Random.Range(shakeForce * 1 / 5, shakeForce * 4 / 5);
        }
        else
        {
            randomPos = Random.Range(-shakeForce * 4 / 5, -shakeForce * 1 / 5);
        }
        
        if (lastRandom != 0)
        {
            Camera.main.GetComponent<Rigidbody2D>().velocity = new Vector2(lastRandom, -lastRandom / Mathf.Abs(lastRandom) * (shakeForce - Mathf.Abs(lastRandom))) * -2;
            lastRandom = 0;
        }
        else
        {
            lastRandom = randomPos;
            Camera.main.GetComponent<Rigidbody2D>().velocity = new Vector2(randomPos, -randomPos / Mathf.Abs(randomPos) * (shakeForce - Mathf.Abs(randomPos)));
        }
    }
}