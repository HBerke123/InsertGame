using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDrainage : MonoBehaviour
{
    public TextMeshProUGUI hpDisplayText;
    public Slider slider;
    public float health = 0;
    public float maxHealth = 100;

    public void Start()
    {
        health = 50;
        UpdateHealthBar(health / maxHealth);
    }

    void Update()
    {
        if (health <= 0)
        {
            health = maxHealth;
            this.transform.position = new Vector3(0f, 2f, 0f);
            UpdateHealthBar(health / maxHealth);
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Mathf.Round(health);
        UpdateHealthBar(health / maxHealth);
    }

    public void UpdateHealthBar(float newHealth)
    {
        slider.value = newHealth;
        hpDisplayText.text = health + "/" + Mathf.Round(maxHealth);
    }
}