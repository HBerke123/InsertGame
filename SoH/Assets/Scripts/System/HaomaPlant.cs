using System.IO;
using UnityEngine;

public class HaomaPlant : MonoBehaviour
{
    public string areaName;
    public float holdTime;
    float th;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.O))
            {
                th = 0;
            }

            if (Input.GetKey(KeyCode.O))
            {
                if ((th == 0))
                {
                    th = Time.time;
                }

                if ((th != 0) && (Time.time - th > holdTime))
                {
                    th = 0;
                    SaveProgress();
                }
            }
        }
    }

    void SaveProgress()
    {
        string path = Application.dataPath + "/Saves/";

        File.WriteAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt", "true\n" + areaName + "\n" + (float.Parse(File.ReadAllText(path + File.ReadAllText(path + "GSave.txt").Split("\n")[0] + ".txt").Split("\n")[2]) + Time.time - GameObject.FindGameObjectWithTag("Player").GetComponent<TimeHolder>().th).ToString() + "\n" + this.transform.position.x.ToString() + " " + this.transform.position.y.ToString() + " 0");
    }
}
