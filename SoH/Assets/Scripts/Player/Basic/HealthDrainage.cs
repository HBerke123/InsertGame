using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDrainage : MonoBehaviour
{
    public TestingTeleportation testingTeleportation;
    public Bar healthBar;
    public float health;
    public float maxHealth;

    public void Start()
    {
        UpdateHealthBar();
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
            UpdateHealthBar();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Round(health);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Round(health);
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.maxValue = maxHealth;
        healthBar.curValue = health;
    }
}