using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject healthDisplay;
    public Collider2D playerCollider;
    public CEDrainage cEDrainage;
    public float healCooldown = 2;
    public float healCooldownHolder = 0;
    public HealthDrainage hpdrain;

    void Start()
    {
        cEDrainage = this.GetComponent<CEDrainage>();
        healthBar = GameObject.Find("HP Bar");
        healthDisplay = GameObject.Find("HP Display");
        playerCollider = this.GetComponent<Collider2D>();
        hpdrain = GetComponent<HealthDrainage>();
    }

    public void Heal(float healed)
    {
        hpdrain.health += healed;
        if (hpdrain.health > hpdrain.maxHealth)
        {
            hpdrain.health = hpdrain.maxHealth;
        }
        Mathf.Round(hpdrain.health);
        hpdrain.UpdateHealthBar();
    }

    public void RegainSTE(float regained)
    {
        cEDrainage.cE += regained;
        if (cEDrainage.cE > cEDrainage.maxCE)
        {
            cEDrainage.cE = cEDrainage.maxCE;
        }
        Mathf.Round(cEDrainage.cE);
        cEDrainage.UpdateCEBar();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("HP Orb"))
        {
            healCooldown = Time.time;
            if (healCooldown - healCooldownHolder >= 0.10)
            {
                Destroy(target.gameObject);
                Heal(20.0f);
                healCooldownHolder = Time.time;
            }
        }
        else if (target.gameObject.CompareTag("STE Tube"))
        {
            healCooldown = Time.time;
            if (healCooldown - healCooldownHolder >= 0.10)
            {
                Destroy(target.gameObject);
                RegainSTE(200.0f);
                healCooldownHolder = Time.time;

            }
        }
    }
}