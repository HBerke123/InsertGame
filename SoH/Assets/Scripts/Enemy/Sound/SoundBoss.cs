using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    public float screamMaxScale;
    public float timeBetweenSkills;
    public float shakeTime;
    public float shakeFrquency;
    public float shakeForce;
    public float jumpForce;
    public float rushSpeed;
    public float rushTime;
    public float soundSpeed;
    public float soundTime;
    public float screamTime;
    public GameObject soundWave;
    public GameObject screamWave;
    GameObject player;
    bool readyToShake;
    int lastDirection;
    int direction;
    float lastRandom;
    public float rth;
    float rrth;
    float sth;
    float ssth;
    float cdth;
    float scth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetDirection();
        Rush();
        lastDirection = direction;
    }

    private void FixedUpdate()
    {
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
            Debug.Log("sa");
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

        if ((sth != 0) && (Time.time - sth >= shakeFrquency) && (Time.time - ssth < shakeTime))
        {
            Shake(shakeForce);
            sth = Time.time;
        }
        else if (Time.time - ssth >= shakeTime)
        {
            sth = 0;
            ssth = 0;
            Camera.main.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if ((ssth == 0) && (rth == 0) && (cdth == 0))
        {
            cdth = Time.time;
        }

        if (false && (scth == 0) && (cdth != 0) && (Time.time - cdth > timeBetweenSkills) && (this.GetComponent<Rigidbody2D>().velocity.x < 0.1f) && (this.GetComponent<Rigidbody2D>().velocity.y < 0.1f) && (ssth == 0) && (rth == 0) && (!readyToShake))
        {
            cdth = 0;
            if (direction == lastDirection)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Rush();
                }
                else
                {
                    SendWaves();
                }
            }
            else
            {
                if (Random.Range(0, 2) == 1)
                {
                    Jump();
                }
                else
                {
                    Scream();
                }
            }
        }
    }

    private void Update()
    {
        if (this.GetComponentInChildren<GroundDetection>().detected && readyToShake)
        {
            readyToShake = false;
            sth = Time.time - shakeFrquency;
            ssth = Time.time;
        }

        if ((this.GetComponent<Rigidbody2D>().velocity.y > 0.1) && !this.GetComponentInChildren<GroundDetection>().detected)
        {
            readyToShake = true;
        }
    }

    void SendWaves()
    {
        GameObject SBox = Instantiate(soundWave, this.transform.position, new Quaternion(0, 0, 0, 0));
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
        for (int direction = 0; direction < 8; direction++)
        {
            GameObject SBox = Instantiate(screamWave, this.transform.position, new Quaternion(0, 0, 0, 0));

            SBox.GetComponent<SkillEnd>().TotalTime = screamTime;
            SBox.GetComponent<GrowingProjectile>().TotalTime = screamTime;
            SBox.GetComponent<GrowingProjectile>().minyscale = 0;
            SBox.GetComponent<GrowingProjectile>().maxyscale = screamMaxScale;
            SBox.GetComponent<GrowingProjectile>().minxscale = 0;
            SBox.GetComponent<GrowingProjectile>().maxxscale = screamMaxScale;
        }

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
        rth = Time.time ;
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

    void Shake(float shakeForce)
    {
        float randomPos;

        if (Random.Range(0, 2) == 1)
        {
            randomPos = Random.Range(shakeForce * 1 / 5, shakeForce * 4 / 5);
        }
        else
        {
            randomPos = Random.Range(-shakeForce * 4 / 5, -shakeForce * 1 / 5);
        }
        
        if (lastRandom != 0)
        {
            Camera.main.GetComponent<Rigidbody2D>().velocity = new Vector2(lastRandom * -2, (shakeForce - lastRandom) * -2);
            lastRandom = 0;
        }
        else
        {
            lastRandom = randomPos;
            Camera.main.GetComponent<Rigidbody2D>().velocity = new Vector2(randomPos, shakeForce - randomPos);
        }
    }
}
