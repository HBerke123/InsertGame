using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public GameObject saves;
    public GameObject menu;
    public MenuOpener menuOpener;
    public TimeControlStop timeControlStop;
    public MenuMovement menuMovement;

    public void Continue()
    {
        string path = Application.dataPath + "/Saves/GSave.txt";

        if (File.ReadAllText(path).Split("\n")[0] == "Save1")
        {
            Savef1();
        }
        else if (File.ReadAllText(path).Split("\n")[0] == "Save2")
        {
            Savef2();
        }
        else if (File.ReadAllText(path).Split("\n")[0] == "Save3")
        {
            Savef3();
        }
    }

    public void ResumeGame()
    {
        menuOpener.Resume();
    }

    public void NewGame()
    {
        menuMovement.currentGroup = 1;
        menuMovement.curCordinate = Vector2.zero;
        menu.SetActive(false);
        saves.SetActive(true);
    }

    public void MainMenu()
    {
        timeControlStop.StopSlowMotion();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Savef1()
    {
        string path = Application.dataPath + "/Saves/GSave.txt";

        File.WriteAllText(path, "Save1");
        SceneManager.LoadScene("MainScene");
    }

    public void Savef2()
    {
        string path = Application.dataPath + "/Saves/GSave.txt";

        File.WriteAllText(path, "Save2");
        SceneManager.LoadScene("MainScene");
    }

    public void Savef3()
    {
        string path = Application.dataPath + "/Saves/GSave.txt";

        File.WriteAllText(path, "Save3");
        SceneManager.LoadScene("MainScene");
    }
}