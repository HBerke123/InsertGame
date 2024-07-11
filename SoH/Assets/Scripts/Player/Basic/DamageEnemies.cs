using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    public bool destroyOnTouch;
    public float damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(damageAmount);
            if (destroyOnTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
