using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDrainage : MonoBehaviour
{
    public float health = 0, maxHealth = 100;
    public GameObject healthBar;
    public GameObject healthDisplay;
    public Image healthBarImage;
    public Slider slider;
    public Collider2D playerCollider;
    public Collider2D enemyCollider;
    public TextMeshProUGUI hpDisplayText;
    public float collisionTime;
    public bool hurt;

    public void Start()
    {
        healthBar = GameObject.Find("HP Bar");
        healthDisplay = GameObject.Find("HP Display");
        health = 100;
        slider = healthBar.GetComponent<Slider>();
        playerCollider = this.GetComponent<Collider2D>();
        hpDisplayText = healthDisplay.GetComponent<TextMeshProUGUI>();
        hpDisplayText.text = health + "/" + maxHealth;
        
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Mathf.Round(health);
        UpdateHealthBar(health / maxHealth);

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
            Debug.Log(health);
        }

        
    }
    public void UpdateHealthBar(float newHealth)
    {
        slider.value = newHealth;
        hpDisplayText.text = health + "/" + Mathf.Round(maxHealth);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            collisionTime = Time.time;
            Debug.Log(collisionTime);
            hurt = true;
        }
        else
        {
            hurt = false;
        }
    }
}