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
            cE = maxCE / 2;
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
    
    public void UpdateCEBar()
    {
        cEBar.maxValue = maxCE;
        cEBar.curValue = cE;
    }
}