using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Update()
    {       
        if (this.transform.position.y < -30)
        {
            if (this.CompareTag("Player")) {
                this.transform.position = new Vector3(0f, 0f, 0f);
                HealthDrainage.health = HealthDrainage.maxHealth;
                HealthDrainage.UpdateHealthBar(HealthDrainage.health / HealthDrainage.maxHealth);
            }
            else if (this.CompareTag("Changeable"))
            {
                this.transform.position = new Vector3(35f, 1f, 0f);
            }
            else
            {
                this.transform.position = new Vector3(180f, 0f, 0f);
            }
        }
    }
}
