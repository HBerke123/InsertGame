using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInfluence : MonoBehaviour
{
    public float smallForcePower;
    public float bigForcePower;
    public float totaltime;
    public float speed;
    public GameObject BigWave;
    public GameObject SmallWave;
    GameObject SBox;
    float th = 0;

    private void Update()
    {
        if (th > 0)
        {
            if (Time.time - th >= totaltime)
            {
                Destroy(SBox);
                th = 0;
            }
        }
    }

    public void SendWave(int direction, bool isforce)
    {
        th = Time.time;
        if (isforce)
        {
            SBox = Instantiate(BigWave, this.transform.position, new Quaternion(0, 0, 0, 0));
            if ((direction == 0) || (direction == 2))
            {
                SBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
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
            else
            {
                SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
            SBox.GetComponent<ForceEnemies>().direction = direction;
            SBox.GetComponent<ForceEnemies>().forcePower = bigForcePower;
        }
        else
        {
            SBox = Instantiate(SmallWave, this.transform.position, new Quaternion(0, 0, 0, 0));
            if ((direction == 0) || (direction == 2))
            {
                SBox.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
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
            else
            {
                SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
            SBox.GetComponent<ForceEnemies>().direction = direction;
            SBox.GetComponent<ForceEnemies>().forcePower = smallForcePower;
        }
    }
}