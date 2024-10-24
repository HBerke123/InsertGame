using System.Collections.Generic;
using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    public bool soundDamage;
    public bool destroyOnTouch;
    public float damageAmount;
    public float blockTime;
    public float noticeTime;
    readonly List<GameObject> damaged = new();

    private void Update()
    {
        if (damaged.Contains(null))
        {
            damaged.Remove(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (collision.GetComponent<Breakable>() != null)
            {
                collision.GetComponent<Breakable>().Break();
            }
            else if ((collision.GetComponent<SoundBreakable>() != null) && soundDamage)
            {
                collision.GetComponent<SoundBreakable>().Break();
            }
            else if ((collision.GetComponent<SoundLever>() != null) && soundDamage)
            {
                collision.GetComponent<SoundLever>().ChangeStatment();
            }
        }

        if (collision.CompareTag("Enemy") && !damaged.Contains(collision.gameObject))
        {
            damaged.Add(collision.gameObject);
            collision.GetComponent<Notice>().noticeTime = Mathf.Max(collision.GetComponent<Notice>().noticeTime, noticeTime);
            collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(damageAmount);
            collision.GetComponent<BlocksOnObject>().blockTime = Mathf.Max(collision.GetComponent<BlocksOnObject>().blockTime, blockTime);
            if (destroyOnTouch)
            {
                Destroy(this.gameObject);
            }
        }
    }
}