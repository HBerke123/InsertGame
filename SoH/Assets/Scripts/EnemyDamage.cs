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
            if (collision.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword")
            {
                ehp.enemyHealth -= 10;
            } 
            else if (collision.GetComponentInParent<PrimaryItems>().itemEquipped == "Spear")
            {
                ehp.enemyHealth -= 5;
            } 
            else if (collision.GetComponentInParent<PrimaryItems>().itemEquipped == "Hammer")
            {
                ehp.enemyHealth -= 20;
            }
        }
    }
}
