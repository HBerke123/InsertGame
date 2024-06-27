using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInfluence : MonoBehaviour
{

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
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
        }
        else
        {
            SBox = Instantiate(SmallWave, this.transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
        }
        
    }
}