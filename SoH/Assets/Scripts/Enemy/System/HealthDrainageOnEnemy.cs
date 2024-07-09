using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrainageOnEnemy : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public void LoseHealth(float amount)
    {
        health -= amount;
        health = Mathf.Round(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GainHealth(float amount)
    {
        health += amount;
        health = Mathf.Round(health);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}