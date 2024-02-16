using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    

    private void Start()
    {
        curHealth = maxHealth;
        rt = this.GetComponent<RectTransform>();
        location = rt.anchoredPosition;
        scale = rt.localScale;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J)) {
            DamagePlayer(10);
        }
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
    }
}
