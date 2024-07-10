using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    public float soundSpeed;
    public float soundTime;
    public float screamSpeed;
    public float screamTime;
    public GameObject soundWave;
    public GameObject screamWave;
    GameObject player;
    int direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

    void SendScream(int direction)
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
                SBox.GetComponent<Rigidbody2D>().velocity = new (Mathf.Sqrt(screamSpeed), Mathf.Sqrt(screamSpeed));
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
        SetDirection();
    }

    void SetDirection()
    {
        if (this.transform.position.x > player.transform.position.x)
        {
            direction = -1;
        } 
        else
        {
            direction = 1;
        }
    }
}
