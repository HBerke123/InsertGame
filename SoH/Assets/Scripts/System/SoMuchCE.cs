using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoMuchCE : MonoBehaviour
{
    public Color baseColor;
    public float maxBrightnessValue;
    public float maxUntransparencyValue;
    public float startValue;
    CEDrainage cED;

    private void Start()
    {
        cED = GameObject.FindGameObjectWithTag("Player").GetComponent<CEDrainage>();
    }

    private void Update()
    {
        if (cED.cE > cED.maxCE * startValue)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(baseColor.r + maxBrightnessValue * (cED.maxCE - cED.cE) / (cED.maxCE - cED.maxCE * startValue), baseColor.g + maxBrightnessValue * (cED.maxCE - cED.cE) / (cED.maxCE - cED.maxCE * startValue), baseColor.b + maxBrightnessValue * (cED.maxCE - cED.cE) / (cED.maxCE - cED.maxCE * startValue), maxUntransparencyValue * (cED.cE - cED.maxCE * startValue) / (cED.maxCE - cED.maxCE * startValue));
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }
}
