using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public SceneManagment sm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sm.curscenenum = 1;
            sm.LoadScene();
        }
    }
}
