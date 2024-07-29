using UnityEngine;

public class BadEffectToObjects : MonoBehaviour
{
    public float duration;
    public bool weakToDash;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (!weakToDash || !collision.GetComponent<Dash>().dashing))
        {
            collision.GetComponent<PoisonEffectsOnPlayer>().badEffectTime = duration;
        }
    }
}
