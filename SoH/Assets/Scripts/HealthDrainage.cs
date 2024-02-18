using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDrainage : MonoBehaviour
{
    public float health = 0, maxHealth = 100;
    public GameObject healthBar;
    public Image healthBarImage;
    public Slider slider;
    public Collider2D playerCollider;
    public Collider2D enemyCollider;
    public float collisionTime;
    public bool hurt;

    public void Start()
    {
        healthBar = GameObject.Find("HP Bar");
        health = 100;
        slider = healthBar.GetComponent<Slider>();
        playerCollider = this.GetComponent<Collider2D>();

    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        UpdateHealthBar(health / 100);
    }
    void Update()
    {
        if (hurt)
        {
            TakeDamage(0.1f);
            if (health <= 0)
            {
                health = 100;
                this.transform.position = new Vector3(0f, 0f, 0f);
            }
        }

        
    }
    public void UpdateHealthBar(float newHealth)
    {
        slider.value = newHealth;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            collisionTime = Time.time;
            hurt = true;
        }
        else
        {
            hurt = false;
        }
    }
}