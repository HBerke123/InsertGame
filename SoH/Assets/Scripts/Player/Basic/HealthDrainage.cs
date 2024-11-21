using UnityEngine;

public class HealthDrainage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float invisibleTime;
    public float currentInvisible;
    public bool isInvisible;

    Bar healthBar;
    float th;

    public void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HPBar").GetComponent<Bar>();
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

    public void TakeDamage(float amount, int num = 0)
    {
        if (!isInvisible)
        {
            if (num == 0) GetComponent<BlocksOnObject>().blockTime = Mathf.Max(GetComponent<BlocksOnObject>().blockTime, invisibleTime / 2);

            currentInvisible = invisibleTime;
            isInvisible = true;
            health -= amount;
            th = Time.time;

            if (health <= 0) Death();

            UpdateHealthBar();
        }
    }

    public void Heal(float amount)
    {
        health += amount;

        if (health > maxHealth) health = maxHealth;

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.maxValue = maxHealth;
        healthBar.curValue = health;
    }

    public void Death()
    {
        GetComponent<ForcesOnObject>().Force = Vector2.zero;
        GetComponent<BlocksOnObject>().blockTime = 0;
        GetComponent<PoisonEffectsOnPlayer>().goodEffectTime = 0;
        GetComponent<PoisonEffectsOnPlayer>().badEffectTime = 0;
        GetComponent<CEDrainage>().cE = GetComponent<CEDrainage>().maxCE / 2;
        health = maxHealth;
        GetComponent<Movement>().stick = false;
        GetComponent<Jump>().stick = false;
        transform.position = Vector3.zero;
        UpdateHealthBar();
    }
}