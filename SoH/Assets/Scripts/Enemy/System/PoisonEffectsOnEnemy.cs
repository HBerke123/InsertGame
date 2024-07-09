using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffectsOnEnemy : MonoBehaviour
{
    public float effectTime;
    public float healFrequency;
    float th;
    float hth;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > effectTime))
        {
            effectTime = 0;
            th = 0;
        }

        if ((th == 0) && (effectTime > 0))
        {
            th = Time.time;
        }

        if ((hth != 0) && (Time.time - hth > healFrequency))
        {
            healFrequency = 0;
            hth = 0;
        }

        if ((hth == 0) && (effectTime > 0))
        {
            hth = Time.time;
        }
    }
}
