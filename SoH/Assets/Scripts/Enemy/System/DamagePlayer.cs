using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float damageAmount;
    public bool damageOnTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthDrainage>().TakeDamage(damageAmount);
            if (damageOnTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
