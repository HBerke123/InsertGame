using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManagment : MonoBehaviour
{
    private void Start()
    {
        string path = Application.dataPath + "/Saves/GSave.txt";

        if (File.Exists(path))
        {

        }
    }

    public void Fsave(int num)
    {
        string path = Application.dataPath + "/Saves/Save" + num.ToString() + ".txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Save" + num.ToString());
        }

        Gsave(num);
    }

    public void Gsave(int num)
    {
        string path = Application.dataPath + "/Saves/GSave.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Save" + num.ToString());
        }
        else
        {
            File.WriteAllText(path, "Save" + num.ToString());
        }
    }

    public void Wsave(int num, float time)
    {
        string path = Application.dataPath + "/Saves/Save" + num.ToString() + ".txt";

        if (File.Exists(path))
        {
            File.WriteAllText(path, "Played: " + time.ToString());
        }
    }
}