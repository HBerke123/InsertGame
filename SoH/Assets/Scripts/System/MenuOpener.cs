using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuOpener : MonoBehaviour
{
    float timeHold;
    public SceneManagment sm;

    private void Start()
    {
        timeHold = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string path = Application.dataPath + "/Saves/GSave.txt";
            if (File.Exists(path))
            {
                File.WriteAllText(path, File.ReadAllText(path) + "\n" + timeHold.ToString());
            }
            sm.curscenenum = 1;
            sm.LoadScene();
        }
    }
}
