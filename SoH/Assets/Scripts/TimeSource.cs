using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSource : MonoBehaviour
{
    public int objID;

    public void Tchanger(int value)
    {
        if (objID == 1) this.GetComponent<Platform>().Tsc(value);
    } 
}
