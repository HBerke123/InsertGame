using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SoundLever : MonoBehaviour
{
    public GameObject platform;
    public GameObject secondPlatform;
    public GameObject thirdPlatform;
    public int num;
    public bool isOn;

    private void Update()
    {
        if (num == 0)
        {
            if (isOn)
            {
                platform.SetActive(false);
                secondPlatform.SetActive(false);
                thirdPlatform.SetActive(false);
            }
        }
        else if (isOn) 
        {
            platform.SetActive(false);
        }
    }

    public void ChangeStatment()
    {
        isOn = !isOn;
    }
}