using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksOnObject : MonoBehaviour
{
    public float blockTime;
    public bool isBlocked;
    float th;

    private void FixedUpdate()
    {
        if ((th == 0) && (blockTime > 0))
        {
            th = Time.time;
            isBlocked = true;
        }

        if ((th != 0) && (Time.time - th > blockTime))
        {
            blockTime = 0;
            th = 0;
            isBlocked = false;
        }
     }
}
