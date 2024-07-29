using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseLight : MonoBehaviour
{
    public int num;
    public float distance;
    public float totalTime;
    float startPos;
    float th;

    private void Start()
    {
        startPos = this.transform.localPosition.x;
        th = Time.time;
    }

    private void Update()
    {
        if (num == 0)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, -90 + (totalTime - th) * 90);
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 90 + (totalTime - th) * -90);
        }
    }
}
