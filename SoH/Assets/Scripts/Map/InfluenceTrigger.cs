using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceTrigger : MonoBehaviour
{
    public InfluencePlatform influencePlatform;
    public int direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BombSound"))
        {
            influencePlatform.SendSound(direction);
        }
        else if (collision.CompareTag("Player") && !collision.GetComponentInChildren<GroundDetection>().detected)
        {
            influencePlatform.SendSound(direction);
        }
    }
}
