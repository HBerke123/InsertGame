using TMPro;
using UnityEngine;

public class BossHPBar : MonoBehaviour
{
    public GameObject Boss;

    private void Update()
    {
        if ((Boss != null) && (Boss.activeSelf == true))
        {
            this.GetComponent<RectTransform>().localScale = Vector3.one;
            this.GetComponentInChildren<Bar>().maxValue = Boss.GetComponent<HealthDrainageOnEnemy>().maxHealth;
            this.GetComponentInChildren<Bar>().curValue = Boss.GetComponent<HealthDrainageOnEnemy>().health;
            this.GetComponentInChildren<TextMeshProUGUI>().text = Boss.GetComponent<HealthDrainageOnEnemy>().bossName;
        }
        else
        {
            this.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
}