using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDomain : MonoBehaviour
{
    public GameObject skillObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            skillObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            skillObject.SetActive(false);
        }
    }
}
