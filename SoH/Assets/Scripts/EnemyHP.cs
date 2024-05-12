using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Bar bar;
    public float enemyHealth = 100;

    private void Start()
    {
        bar.maxValue = 100;
    }

    private void Update()
    {
        bar.curValue = enemyHealth;
    }
}
