using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject healthDisplay;
    public Collider2D playerCollider;
    public STEDrainage sTEDrainage;
    public float healCooldown = 2;
    public float healCooldownHolder = 0;
    public HealthDrainage hpdrain;

    void Start()
    {
        sTEDrainage = this.GetComponent<STEDrainage>();
        healthBar = GameObject.Find("HP Bar");
        healthDisplay = GameObject.Find("HP Display");
        playerCollider = this.GetComponent<Collider2D>();
        hpdrain = GetComponent<HealthDrainage>();
    }

    public void Heal(float healed)
    {
        hpdrain.health += healed;
        if (hpdrain.health > hpdrain.maxHealth)
        {
            hpdrain.health = hpdrain.maxHealth;
        }
        Mathf.Round(hpdrain.health);
        UpdateHealthBar(hpdrain.health / hpdrain.maxHealth);

    }
    public void RegainSTE(float regained)
    {
        sTEDrainage.ste += regained;
        if (sTEDrainage.ste > sTEDrainage.maxSTE)
        {
            sTEDrainage.ste = sTEDrainage.maxSTE;
        }
        Mathf.Round(sTEDrainage.ste);
        sTEDrainage.UpdateSTEBar(sTEDrainage.ste / sTEDrainage.maxSTE);
    }
    public void UpdateHealthBar(float newHealth)
    {
        HealthDrainage.slider.value = newHealth;
        HealthDrainage.hpDisplayText.text = hpdrain.health.ToString() + "/" + Mathf.Round(hpdrain.maxHealth).ToString();
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("HP Orb"))
        {
            healCooldown = Time.time;
            if (healCooldown - healCooldownHolder >= 0.10)
            {
                Destroy(target.gameObject);
                Heal(20.0f);
                Debug.Log("+20 HP");
                healCooldownHolder = Time.time;
            }
        }
        else if (target.gameObject.CompareTag("STE Tube"))
        {
            healCooldown = Time.time;
            if (healCooldown - healCooldownHolder >= 0.10)
            {
                Destroy(target.gameObject);
                RegainSTE(200.0f);
                Debug.Log("+200 STE");
                healCooldownHolder = Time.time;

            }
        }
    }
}