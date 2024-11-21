using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTrigger : MonoBehaviour
{
    List<GameObject> touchings = new();
    public BoxCollider2D leafCollider;

    private void Update()
    {
        if (touchings.Count != 0)
        {
            leafCollider.enabled = false;

            for (int i = 0; i < touchings.Count; i++)
            {
                if (!this.GetComponent<BoxCollider2D>().IsTouching(touchings[i].GetComponent<Collider2D>()))
                {
                    touchings.RemoveAt(i);
                }
            }
        }
        else
        {
            leafCollider.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") && ((collision.GetComponent<PoisonEffectsOnPlayer>().goodEffectTime > 0) || (collision.GetComponent<PoisonEffectsOnPlayer>().badEffectTime > 0))) || collision.CompareTag("Smoke"))
        {
            if (!touchings.Contains(collision.gameObject))
            {
                touchings.Add(collision.gameObject);
            }
        }
    }
}