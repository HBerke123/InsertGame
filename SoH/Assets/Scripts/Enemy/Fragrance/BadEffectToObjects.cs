using UnityEngine;

public class BadEffectToObjects : MonoBehaviour
{
    public float duration;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PoisonEffectsOnPlayer>().badEffectTime = duration;
        }
    }
}
