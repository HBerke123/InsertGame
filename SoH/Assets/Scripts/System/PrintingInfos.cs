using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PrintingInfos : MonoBehaviour
{
    public int savenum;
    public TextMeshProUGUI text;
    
    void Start()
    {
        string path = Application.dataPath + "/Saves/Save";
        text.text = "Where: " + File.ReadAllText(path + savenum + ".txt").Split("\n")[1] +"\n" + "Played: " + File.ReadAllText(path + savenum + ".txt").Split("\n")[2];
    }
}
