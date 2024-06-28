using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnd : MonoBehaviour
{
    public float maxyscale;
    public float minyscale;
    public float TotalTime;
    public bool IsSwordWave;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void Update()
    {
        
        if (IsSwordWave)
        {
            this.transform.localScale = new Vector3(0.5f, minyscale + maxyscale * (Time.time - th), 1);
        }
        
        if (Time.time - th > TotalTime)
        {
            Destroy(this.gameObject);
        }
    }
}
