using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    public GameObject Boss;

    private void Update()
    {
        if (Boss != null)
        {
            this.GetComponent<RectTransform>().localScale = Vector3.one;
            this.GetComponentInChildren<Bar>().maxValue = Boss.GetComponent<HealthDrainageOnEnemy>().maxHealth;
            this.GetComponentInChildren<Bar>().curValue = Boss.GetComponent<HealthDrainageOnEnemy>().health;
        }
        else
        {
            this.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
}
