using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDrainage : MonoBehaviour
{
    public TestingTeleportation testingTeleportation;
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
            foreach (GameObject gameObject in testingTeleportation.enemies)
            {
                gameObject.SetActive(false);
            }

            health = maxHealth;
            this.GetComponent<Movement>().stick = false;
            this.GetComponent<Jump>().stick = false;
            this.transform.position = Vector3.zero;
            UpdateHealthBar(health / maxHealth);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Round(health);
        UpdateHealthBar(health / maxHealth);
    }

    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Round(health);
        UpdateHealthBar(health / maxHealth);
    }

    public void UpdateHealthBar(float newHealth)
    {
        slider.value = newHealth;
    }
}