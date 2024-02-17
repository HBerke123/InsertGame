using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDrainage : MonoBehaviour
{
    public float health = 0, maxHealth = 1;
    public GameObject healthBar;
    public Image healthBarImage;
    public Slider slider;

    public void Start()
    {
        healthBar = GameObject.Find("HP Bar");
        health = 1;
        slider = healthBar.GetComponent<Slider>();

    }
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.
        health -= 0.1f;
        UpdateHealthBar(health);
        Debug.Log(health);
        if(health < 0)
        {
            health = 0;
        }
    }
    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage();
        }
    }
    public void UpdateHealthBar(float newHealth)
    {
        slider.value = newHealth;
    }
}