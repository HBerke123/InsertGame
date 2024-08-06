using UnityEngine;

public class HealthDrainageOnEnemy : MonoBehaviour
{
    public AudioClip bossFelled;
    public float healPlayer;
    public float health;
    public float maxHealth;
    public int enemyNum;
    public bool isBoss;
    public string bossName;
    BossHPBar bossHpBar;
    AudioSource as1;

    private void Start()
    {
        as1 = this.GetComponent<AudioSource>();
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
            else if (enemyNum == 7)
            {
                as1.PlayOneShot(bossFelled);
            }
            else if (enemyNum == 8)
            {
                as1.PlayOneShot(bossFelled);
            }

            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDrainage>().Heal(healPlayer);

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