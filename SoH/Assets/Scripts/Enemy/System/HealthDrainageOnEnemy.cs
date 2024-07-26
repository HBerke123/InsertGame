using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrainageOnEnemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int enemyNum;
    public bool isBoss;
    public string bossName;
    BossHPBar bossHpBar;

    private void Start()
    {
        bossHpBar = GameObject.FindGameObjectWithTag("BossHPBar").GetComponent<BossHPBar>();     
    }

    private void Update()
    {
        if (isBoss)
        {
            bossHpBar.Boss = this.gameObject;
        }
    }

    public void LoseHealth(float amount)
    {
        health -= amount;
        health = Mathf.Round(health);
        if (health <= 0)
        {
            if (enemyNum == 1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().stick = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>().stick = false;
            }
            else if (enemyNum == 5)
            {
                this.GetComponent<GoodSmellingFlower>().Smell();
            }
            else if (enemyNum == 6)
            {
                this.GetComponent<BadSmellingFlower>().Smell();
            }

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