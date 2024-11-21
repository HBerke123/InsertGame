using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject firstMenu;

    public GameObject saves;
    public GameObject menu;
    public TimeControlStop timeControlStop;
    public MenuMovement menuMovement;

    MenuOpener menuOpener;
    string path;

    private void Awake()
    {
        path = Application.dataPath + "/Saves/GSave.txt";
        menuOpener = GameObject.FindGameObjectWithTag("Player").GetComponent<MenuOpener>();
    }
    
    public void Continue()
    {
        switch (File.ReadAllText(path).Split("\n")[0])
        {
            case ("Save1"):
                Savef1();
                break;
            case ("Save2"):
                Savef2();
                break;
            case ("Save3"):
                Savef3();
                break;
        }
    }

    public void ResumeGame() => menuOpener.Resume();

    public void Options()
    {
        optionsMenu.SetActive(true);
        firstMenu.SetActive(false);
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

    public void ExitGame() => Application.Quit();

    public void Savef1()
    {
        File.WriteAllText(path, "Save1");
        SceneManager.LoadScene("MainScene");
    }

    public void Savef2()
    {
        File.WriteAllText(path, "Save2");
        SceneManager.LoadScene("MainScene");
    }

    public void Savef3()
    {
        File.WriteAllText(path, "Save3");
        SceneManager.LoadScene("MainScene");
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        firstMenu.SetActive(true);
    }
}