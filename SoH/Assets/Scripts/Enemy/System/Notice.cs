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
        if ((Time.time - th > noticeTime) && (noticeTime > 0)) 
        {
            noticeTime = 0;
        }

        if ((th == 0) && (noticeTime > 0))
        {
            th = Time.time;
        }

        if (noticeTime == 0)
        {
            isNoticed = false;
        }
        else
        {
            isNoticed = true;
        }
    }
}
