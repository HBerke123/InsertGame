using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject healthDisplay;
    public Collider2D playerCollider;
    public
    void Start()
    {
        healthBar = GameObject.Find("HP Bar");
        healthDisplay = GameObject.Find("HP Display");

    }

    void Update()
    {
        
        if (HealthDrainage.health >= HealthDrainage.maxHealth)
        {
            HealthDrainage.health = HealthDrainage.maxHealth;
            UpdateHealthBar(HealthDrainage.health / HealthDrainage.maxHealth);
        }
        
    }
    public void Heal(float healed)
    {
        HealthDrainage.health += healed;
        Mathf.Round(HealthDrainage.health);
        UpdateHealthBar(HealthDrainage.health / HealthDrainage.maxHealth);
    }
    public static void UpdateHealthBar(float newHealth)
    {
        HealthDrainage.slider.value = newHealth;
        HealthDrainage.hpDisplayText.text = HealthDrainage.health + "/" + Mathf.Round(HealthDrainage.maxHealth);
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("HP Orb"))
        {
        Heal(20.0f);
        }
    }
}
