using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundLever : MonoBehaviour
{
    public GameObject platform;
    public GameObject secondPlatform;
    public int num;
    bool isOn;

    private void Update()
    {
        if (num == 0)
        {
            if (isOn)
            {
                platform.SetActive(false);
                secondPlatform.SetActive(false);
            }
        }
    }

    public void ChangeStatment()
    {
        isOn = !isOn;
    }
}