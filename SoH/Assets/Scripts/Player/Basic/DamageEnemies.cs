using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    public bool destroyOnTouch;
    public float damageAmount;
    List<GameObject> damaged = new();

    private void Update()
    {
        if (damaged.Contains(null))
        {
            damaged.Remove(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !damaged.Contains(collision.gameObject))
        {
            damaged.Add(collision.gameObject);
            collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(damageAmount);
            if (destroyOnTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
