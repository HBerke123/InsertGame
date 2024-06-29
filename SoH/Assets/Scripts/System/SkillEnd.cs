using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnd : MonoBehaviour
{
    public float TotalTime;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void Update()
    {   
        if (Time.time - th > TotalTime)
        {
            Destroy(this.gameObject);
        }
    }
}
