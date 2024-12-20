using System.IO;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public float saveFrequency;

    float th;
    string path;

    private void Awake()
    {
        path = Application.dataPath + "/Saves/";
    }

    private void FixedUpdate()
    {
        if (File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[0] == "false")
        {
            if (th == 0) th = Time.time;

            if ((th != 0) && (Time.time - th > saveFrequency))
            {
                SaveProgress();
                th = Time.time;
            }
        }
        else Destroy(this);
    }

    void SaveProgress()
    {
        File.WriteAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt", "false\nNull\n" + (float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[2]) + Time.time - GameObject.FindGameObjectWithTag("Player").GetComponent<TimeHolder>().th).ToString() + "\n" + (float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[2]) + Time.time - this.GetComponent<TimeHolder>().th).ToString() + "\n" + this.transform.position.x.ToString() + " " + this.transform.position.y.ToString() + " 0");
    }
}