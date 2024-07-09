using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AutoSave : MonoBehaviour
{
    public float saveFrequency;
    float th;

    private void FixedUpdate()
    {
        string path = Application.dataPath + "/Saves/";
        
        if (File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[0] == "false")
        {
            if (th == 0)
            {
                th = Time.time;
            }

            if ((th != 0) && (Time.time - th > saveFrequency))
            {
                SaveProgress();
                th = Time.time;
                Debug.Log("sa");
            }
        }
        else
        {
            Destroy(this);
        }
    }

    void SaveProgress()
    {
        string path = Application.dataPath + "/Saves/";

        File.WriteAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt", "false\nNull\n" + (float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[2]) + Time.time - GameObject.FindGameObjectWithTag("Player").GetComponent<TimeHolder>().th).ToString());
    }
}
