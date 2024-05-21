using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxValue;
    public float curValue;
    private float percentage;
    public float length = 2.4f;

    private void Update()
    {
        if (curValue <= 0) {
            percentage = 0;
        }
        else
        {
            percentage = curValue / maxValue;
        }

        this.transform.localScale = new Vector3( length * percentage, this.transform.localScale.y, 0);
        this.transform.localPosition = new Vector3( (1 - percentage) * -length/2 , 1, 0);
    }
}
