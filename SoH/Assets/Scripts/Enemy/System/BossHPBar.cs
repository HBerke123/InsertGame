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
            this.GetComponent<Slider>().value = Boss.GetComponent<HealthDrainageOnEnemy>().health  / Boss.GetComponent<HealthDrainageOnEnemy>().maxHealth;
        }
        else
        {
            this.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
}
