using UnityEngine;

public class HealthDrainage : MonoBehaviour
{
    public TestingTeleportation testingTeleportation;
    public Bar healthBar;
    public float health;
    public float maxHealth;
    public float invisibleTime;
    public float currentInvisible;
    public bool isInvisible;
    float th;

    public void Start()
    {
        UpdateHealthBar();
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > currentInvisible))
        {
            currentInvisible = 0;
            th = 0;
            isInvisible = false;
        }
    }

    public void TakeDamage(float amount)
    {
        currentInvisible = invisibleTime;
        isInvisible = true;
        health -= amount;
        th = Time.time;

        if (health <= 0)
        {
            Death();
        }
        
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.maxValue = maxHealth;
        healthBar.curValue = health;
    }

    public void Death()
    {
        foreach (GameObject gameObject in testingTeleportation.enemies)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }

        this.GetComponent<BlocksOnObject>().blockTime = 0;
        this.GetComponent<PoisonEffectsOnPlayer>().goodEffectTime = 0;
        this.GetComponent<PoisonEffectsOnPlayer>().badEffectTime = 0;
        this.GetComponent<CEDrainage>().cE = this.GetComponent<CEDrainage>().maxCE / 2;
        health = maxHealth;
        this.GetComponent<Movement>().stick = false;
        this.GetComponent<Jump>().stick = false;
        this.transform.position = Vector3.zero;
        UpdateHealthBar();
    }
}