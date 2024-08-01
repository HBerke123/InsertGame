using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseLight : MonoBehaviour
{
    public int num;
    public float turnTime;
    public GameObject boss;
    float th;
    bool turned;

    private void Start()
    {
        th = Time.time;
    }

    private void Update()
    {
        if (boss == null)
        {
            Destroy(this.gameObject);
        }

        if (num == 0)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, -90 + (Time.time - th) / turnTime * 90);

            if ((this.transform.localRotation.eulerAngles.z < 269) && !turned)
            {
                turned = true;
            }
            else if ((this.transform.localRotation.eulerAngles.z > 91) && turned)
            {
                num = 1;
                th = Time.time;
                turned = false;
            }
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 90 + (Time.time - th) / turnTime * -90);

            if ((this.transform.localRotation.eulerAngles.z > 91) && !turned)
            {
                turned = true;
            }
            else if ((this.transform.localRotation.eulerAngles.z < 269) && turned)
            {
                num = 0;
                th = Time.time;
                turned = false;
            }
        }  
    }
}
