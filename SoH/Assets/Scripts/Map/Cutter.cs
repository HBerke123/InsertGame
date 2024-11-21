using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CheckpointRecorder>().LoadCheckpoint();
            collision.GetComponent<HealthDrainage>().TakeDamage(damage, 1);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}