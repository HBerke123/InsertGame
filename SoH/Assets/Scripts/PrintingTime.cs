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
        string pathS = Application.dataPath + "/Saves/Save";
        
        if (File.Exists(path))
        {
            if (File.ReadAllText(path).Contains("Save" + savenum.ToString()))
            {
                string[] values = File.ReadAllText(path).Split("\n");
                if (File.Exists(pathS + savenum.ToString() + ".txt"))
                {
                    float total = float.Parse(values[1]) + float.Parse(File.ReadAllText(pathS + savenum.ToString() + ".txt"));
                    File.WriteAllText(pathS + savenum.ToString() + ".txt", total.ToString());
                }
                this.GetComponent<TextMeshProUGUI>().text = "Played: " + File.ReadAllText(pathS + savenum.ToString() + ".txt");
            }
            else if (File.Exists(pathS + savenum.ToString() + ".txt"))
            {
                this.GetComponent<TextMeshProUGUI>().text = "Played: " + File.ReadAllText(pathS + savenum.ToString() + ".txt");
            }
        }
    }
}
