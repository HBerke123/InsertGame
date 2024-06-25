using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CEDrainage : MonoBehaviour
{
    public float ce, maxCE = 1000;
    public GameObject ceBar;
    public GameObject ceDisplay;

    public void Start()
    {
        ce = 500;
        UpdateCEBar();
    }

    public void LoseCE(float dmg)
    {
        ce -= dmg;
        Mathf.Round(ce);
        UpdateCEBar();
    }

    public void GainCE(float dmg)
    {
        ce += dmg;
        Mathf.Round(ce);
        UpdateCEBar();
    }

    void Update()
    {
        if (ce <= 0)
        {
            ce = maxCE;
            this.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
    
    public void UpdateCEBar()
    {
        ceBar.GetComponent<Slider>().value = ce / maxCE;
        ceDisplay.GetComponent<TextMeshProUGUI>().text = ce + " / " + Mathf.Round(maxCE);
    }
}