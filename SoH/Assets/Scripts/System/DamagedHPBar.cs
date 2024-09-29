using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedHPBar : MonoBehaviour
{
    public float perTime;
    GameObject hPBar;
    public float th;

    private void Start()
    {
        hPBar = GameObject.FindGameObjectWithTag("HPBar");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > perTime))
        {
            th = Time.time;
            this.GetComponent<Bar>().curValue -= 0.1f;

            if (this.GetComponent<Bar>().curValue <= hPBar.GetComponent<Bar>().curValue)
            {
                th = 0;
            }
        }
        
        if ((th == 0) && (this.GetComponent<Bar>().curValue > hPBar.GetComponent<Bar>().curValue))
        {
            th = Time.time;
        }
    }
}
