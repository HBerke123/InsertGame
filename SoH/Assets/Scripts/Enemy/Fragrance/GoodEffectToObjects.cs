using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEffectToObjects : MonoBehaviour
{
    public float duration;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PoisonEffectsOnPlayer>().goodEffectTime = duration;
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<PoisonEffectsOnEnemy>().effectTime = duration;
        }
    }
}
