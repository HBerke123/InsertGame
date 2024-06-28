using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamUse : MonoBehaviour
{
    public GameObject ScreamWave;
    public float speed;
    public float totaltime;
    public float btime;
    public float rtime;
    float th = 0;
    float rth = 0;
    int ammo = 3;
    int direction = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = 2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 3;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponentInParent<Movement>().enabled = false;
            th = Time.time;
            rth = 0;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            this.GetComponentInParent<Movement>().enabled = true;
            th = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(this.GetComponentInParent<Rigidbody2D>().velocity.x - this.GetComponentInParent<Rigidbody2D>().velocity.x * (this.GetComponentInParent<Movement>().sspeed / 10), this.GetComponentInParent<Rigidbody2D>().velocity.y);
            if ((ammo > 0) && (Time.time - th > btime) && (th > 0))
            {
                SendWave(direction);
                th = Time.time;
                ammo--;
            }
            else if ((ammo == 0))
            {
                if (rth == 0)
                {
                    rth = Time.time;
                }

                if ((rth > 0) && (Time.time - rth > rtime))
                {
                    ammo++;
                    rth = 0;
                }
            }
        }
        else
        {
            if ((rth > 0) && (Time.time - rth > rtime) && (ammo < 3))
            {
                ammo++;
                rth = Time.time;
            }
        }
    }

    public void SendWave(int direction)
    {
        GameObject SBox = Instantiate(ScreamWave, this.transform.position, new Quaternion(0, 0, 0, 0));

        if (direction == 0)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (direction == 1)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
        else if (direction == 2)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else if (direction == 3)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }

        SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
    }
}
