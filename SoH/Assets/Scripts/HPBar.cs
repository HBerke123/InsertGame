using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public Slider healthBarSlider;
    public Health playerHP;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBarSlider = GetComponent<Slider>();
        healthBarSlider.maxValue = playerHP.maxHealth;
        healthBarSlider.value = playerHP.maxHealth;
    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
