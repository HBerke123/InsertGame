using UnityEngine;

public class HealthDrainageOnEnemy : MonoBehaviour
{
    public AudioClip bossFelled;
    public GameObject platform;
    public float blockTime;
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
        this.GetComponent<BlocksOnObject>().AddBlock(blockTime);

        if (health <= 0)
        {
            switch (enemyNum)
            {
                case 1:
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().stick = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>().stick = false;
                    break;
                case 5:
                    this.GetComponent<GoodSmellingFlower>().Smell();
                    break;
                case 6:
                    this.GetComponent<BadSmellingFlower>().Smell();
                    break;
                case 7:
                    platform.GetComponent<SpecialEvent>().eventStarted = true;
                    as1.PlayOneShot(bossFelled);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<ObtainSkills>().obtainedSound = true;
                    break;
                case 8:
                    as1.PlayOneShot(bossFelled);
                    break;
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