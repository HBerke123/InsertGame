using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDrainage : MonoBehaviour
{
    public static float health = 0, maxHealth = 100;
    public GameObject healthBar;
    public GameObject healthDisplay;
    public static TextMeshProUGUI hpDisplayText;
    public Image healthBarImage;
    public static Slider slider;
    public Collider2D playerCollider;
    public Collider2D enemyCollider;
    public bool hurt;
    public float cooldown;
    public float cooldownHolder;

    public void Start()
    {
        healthBar = GameObject.Find("HP Bar");
        healthDisplay = GameObject.Find("HP Display");
        health = 50;
        slider = healthBar.GetComponent<Slider>();
        playerCollider = this.GetComponent<Collider2D>();
        hpDisplayText = healthDisplay.GetComponent<TextMeshProUGUI>();
        UpdateHealthBar(health / maxHealth);
        hpDisplayText.text = health + "/" + maxHealth;

    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Mathf.Round(health);
        UpdateHealthBar(health / maxHealth);
        cooldownHolder = Time.time;

    }
    void Update()
    {
        if (hurt)
        {
            cooldown = Time.time;
            if (cooldown - cooldownHolder >= 2)
            {
                TakeDamage(5.0f);
            }
            if (health <= 0)
            {
                health = maxHealth;
                this.transform.position = new Vector3(0f, 0f, 0f);
                UpdateHealthBar(health / maxHealth);
            }
        }


    }
    public static void UpdateHealthBar(float newHealth)
    {
        slider.value = newHealth;
        hpDisplayText.text = health + "/" + Mathf.Round(maxHealth);


    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
<<<<<<< HEAD
=======
            collisionTime = Time.time;
>>>>>>> b727eef3a8c145a1b2f530ff7efe703408c9b207
            hurt = true;
        }
        else
        {
            hurt = false;
        }
    }
}