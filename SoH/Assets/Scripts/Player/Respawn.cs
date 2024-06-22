using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public HealthDrainage hpdrain;
    void Start()
    {
        hpdrain = GetComponent<HealthDrainage>();
    }
    void Update()
    {       
        if (this.transform.position.y < -30)
        {
            if (this.CompareTag("Player")) {
                this.transform.position = new Vector3(0f, 0f, 0f);
                
                hpdrain.health = hpdrain.maxHealth;
                hpdrain.UpdateHealthBar(hpdrain.health / hpdrain.maxHealth);
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
