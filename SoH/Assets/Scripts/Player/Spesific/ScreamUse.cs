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
    public float forcePower;
    float th = 0;
    float rth = 0;
    int ammo = 3;
    int direction = 0;

    private void Update()
    {
        float cursorx = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.GetComponentInParent<Transform>().position.x;
        float cursory = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.GetComponentInParent<Transform>().position.y;

        if (Mathf.Abs(cursorx) >= Mathf.Abs(cursory))
        {
            if (Mathf.Abs(cursorx) / cursorx == 1)
            {
                direction = 1;
            }
            else
            {
                direction = 3;
            }
        }
        else
        {
            if (Mathf.Abs(cursory) / cursory == 1)
            {
                direction = 0;
            }
            else
            {
                direction = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            th = Time.time;
            rth = 0;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            th = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
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
        if ((direction == 0) || (direction == 2))
        {
            SBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        if (direction == 0)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (direction == 1)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else if (direction == 2)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else if (direction == 3)
        {
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }

        SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
        SBox.GetComponent<ForceEnemies>().direction = direction;
        SBox.GetComponent<ForceEnemies>().forcePower = forcePower;
    }
}
