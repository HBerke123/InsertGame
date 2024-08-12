using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    float triggeredTime;
    float th;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("LaserTrigger"))
        {
            triggeredTime = Mathf.Max(triggeredTime, 1);
        }
    }

    private void FixedUpdate()
    {
        if ((triggeredTime > 0) && (th == 0))
        {
            th = Time.time;
        }
        
        if ((Time.time - th > triggeredTime) && (th != 0))
        {
            triggeredTime = 0;
            th = 0;
        }
    }
}
