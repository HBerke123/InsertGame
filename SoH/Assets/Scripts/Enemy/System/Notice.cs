using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public float noticeTime;
    public bool isNoticed;
    float th;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > noticeTime) && (noticeTime > 0)) 
        {
            noticeTime = 0;
            th = 0;
        }

        if ((th == 0) && (noticeTime > 0))
        {
            th = Time.time;
        }
    }

    public void AddTime(float amount)
    {
        noticeTime = Mathf.Max(amount, noticeTime);
        th = 0;
    }

    private void Update()
    {
        if (noticeTime > 0)
        {
            isNoticed = true;
        }
        else
        {
            isNoticed = false;
        }
    }
}
