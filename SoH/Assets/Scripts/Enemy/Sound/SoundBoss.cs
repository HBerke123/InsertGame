using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    public float timeBetweenSkills;
    public float shakeTime;
    public float shakeFrquency;
    public float shakeForce;
    public float jumpForce;
    public float rushSpeed;
    public float rushTime;
    public float soundSpeed;
    public float soundTime;
    public float screamSpeed;
    public float screamTime;
    public GameObject soundWave;
    public GameObject screamWave;
    GameObject player;
    bool readyToShake;
    int lastDirection;
    int direction;
    float lastRandom;
    float rth;
    float sth;
    float ssth;
    float cdth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Scream();
        SetDirection();
        lastDirection = direction;
    }

    private void FixedUpdate()
    {
        if ((rth != 0) && (Time.time - rth >= rushTime))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            rth = 0;
            SetDirection();
        }
        else if (rth != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(rushSpeed * direction, this.GetComponent<Rigidbody2D>().velocity.y);
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

        if (false && (cdth != 0) && (Time.time - cdth > timeBetweenSkills) && (this.GetComponent<Rigidbody2D>().velocity.x < 0.1f) && (this.GetComponent<Rigidbody2D>().velocity.y < 0.1f) && (ssth == 0) && (rth == 0) && (!readyToShake))
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

            if (direction % 2 == 1)
            {
                if (direction / 2 == 0)
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(0, screamSpeed);
                }
                else if (direction / 2 == 1)
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(screamSpeed, 0);
                }
                else if (direction / 2 == 2)
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(0, -screamSpeed);
                }
                else
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(-screamSpeed, 0);
                }
            }
            else
            {
                if (direction / 2 == 0)
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 45);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(Mathf.Sqrt(screamSpeed), Mathf.Sqrt(screamSpeed));
                }
                else if (direction / 2 == 1)
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 135);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(Mathf.Sqrt(screamSpeed), -Mathf.Sqrt(screamSpeed));
                }
                else if (direction / 2 == 2)
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 135);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(-Mathf.Sqrt(screamSpeed), Mathf.Sqrt(screamSpeed));
                }
                else
                {
                    SBox.transform.localRotation = Quaternion.Euler(0, 0, 45);
                    SBox.GetComponent<Rigidbody2D>().velocity = new(-Mathf.Sqrt(screamSpeed), -Mathf.Sqrt(screamSpeed));
                }
            }

            SBox.GetComponent<SkillEnd>().TotalTime = screamTime;
            SBox.GetComponent<GrowingWave>().minyscale = 0;
            SBox.GetComponent<GrowingWave>().maxyscale = 0;
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
        rth = Time.time;
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
