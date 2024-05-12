using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyHP ehp;

    private void Start()
    {
        ehp = this.GetComponent<EnemyHP>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            ehp.enemyHealth -= 10;
        }
    }
}
