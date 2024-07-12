using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float damageAmount;
    public bool destroyOnTouch;
    bool damaged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !damaged)
        {
            damaged = true;
            collision.GetComponent<HealthDrainage>().TakeDamage(damageAmount);
            if (destroyOnTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
