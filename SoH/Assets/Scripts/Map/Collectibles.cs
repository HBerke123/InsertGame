using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject healthDisplay;
    public Collider2D playerCollider;
    public CEDrainage ceDrainage;
    public float healCooldown = 2;
    public float healCooldownHolder = 0;
    public HealthDrainage hpdrain;

    void Start()
    {
        ceDrainage = this.GetComponent<CEDrainage>();
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
        UpdateHealthBar(hpdrain.health / hpdrain.maxHealth);

    }
    public void RegainSTE(float regained)
    {
        ceDrainage.ce += regained;
        if (ceDrainage.ce > ceDrainage.maxCE)
        {
            ceDrainage.ce = ceDrainage.maxCE;
        }
        Mathf.Round(ceDrainage.ce);
        ceDrainage.UpdateCEBar();
    }
    public void UpdateHealthBar(float newHealth)
    {
        HealthDrainage.slider.value = newHealth;
        HealthDrainage.hpDisplayText.text = hpdrain.health.ToString() + "/" + Mathf.Round(hpdrain.maxHealth).ToString();
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