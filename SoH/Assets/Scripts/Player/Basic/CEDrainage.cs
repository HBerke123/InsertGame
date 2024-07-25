using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CEDrainage : MonoBehaviour
{
    public float cE, maxCE;
    public Bar cEBar;

    public void Start()
    {
        cE = 500;
        UpdateCEBar();
    }

    public void LoseCE(float dmg)
    {
        cE -= dmg;
        Mathf.Round(cE);
        UpdateCEBar();
    }

    public void GainCE(float dmg)
    {
        cE += dmg;
        Mathf.Round(cE);
        UpdateCEBar();
    }

    void Update()
    {
        if ((cE <= 0) || (cE >= maxCE))
        {
            this.GetComponent<HealthDrainage>().Death();
        }
    }
    
    public void UpdateCEBar()
    {
        cEBar.maxValue = maxCE;
        cEBar.curValue = cE;
    }
}