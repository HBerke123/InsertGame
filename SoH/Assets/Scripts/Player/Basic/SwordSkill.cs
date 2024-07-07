using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : MonoBehaviour
{
    public float maxyscale;
    public float minyscale;
    public float speed;
    public float totaltime;
    public float forcePower;
    public GameObject SkillBox;
    GameObject SBox;

    public void SkillStart(int direction)
    {
        SBox = Instantiate(SkillBox, this.transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
        SBox.GetComponent<SkillEnd>().TotalTime = totaltime;
        SBox.GetComponent<SwordWave>().minyscale = minyscale;
        SBox.GetComponent<SwordWave>().maxyscale = maxyscale;

        if (direction == -1)
        {
            SBox.GetComponent<ForceEnemies>().direction = 3;
        }
        else
        {
            SBox.GetComponent<ForceEnemies>().direction = 1;
        }
        
        SBox.GetComponent<ForceEnemies>().forcePower = forcePower;
    }
}