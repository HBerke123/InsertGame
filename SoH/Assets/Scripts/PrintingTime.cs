using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PrintingTime : MonoBehaviour
{
    public int savenum;
    void Start()
    {
        string path = Application.dataPath + "/Saves/GSave.txt";
        string pathS = Application.dataPath + "/Saves/Save" + savenum.ToString() + ".txt";
        
        if (File.Exists(path))
        {
            if (File.ReadAllText(path).Contains("Save" + savenum.ToString()))
            {
                string[] values = File.ReadAllText(path).Split("\n");
                if (File.Exists(pathS))
                {
                    Debug.Log(File.ReadAllText(pathS));
                    float total = float.Parse(values[1]) + float.Parse("5");
                    File.WriteAllText(pathS, total.ToString());
                }
                this.GetComponent<TextMeshProUGUI>().text = "Played: " + File.ReadAllText(pathS);
            }
            else if (File.Exists(pathS))
            {
                this.GetComponent<TextMeshProUGUI>().text = "Played: " + File.ReadAllText(pathS);
            }
        }
    }
}
