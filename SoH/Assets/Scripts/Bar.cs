using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxValue;
    public float curValue;
    private float percentage;

    private void Update()
    {
        if (curValue <= 0) {
            percentage = 0;
        }
        else
        {
            percentage = curValue / maxValue;
        }

        this.transform.localScale = new Vector3( 2.4f * percentage, 0.4f, 0);
        this.transform.localPosition = new Vector3( (1 - percentage) * -1.2f , 1, 0);
    }
}
