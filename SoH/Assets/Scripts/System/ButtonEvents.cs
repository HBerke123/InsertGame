using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject firstMenu;
    [SerializeField] GameObject displayMenu;
    [SerializeField] GameObject languageMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject creditsMenu;
    [SerializeField] bool isMain;

    public GameObject saves;
    public GameObject menu;
    public TimeControlStop timeControlStop;
    public MenuMovement menuMovement;

    MenuOpener menuOpener;
    string path;

    private void Awake()
    {
        path = Application.dataPath + "/Saves/GSave.txt";

        if (isMain) menuOpener = GameObject.FindGameObjectWithTag("Player").GetComponent<MenuOpener>();
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
        menuMovement.currentGroup = 2;
        menuMovement.curCordinate = Vector2.zero;
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
        menuMovement.currentGroup = 0;
        menuMovement.curCordinate = Vector2.zero;
    }

    public void DisplayMenu()
    {
        optionsMenu.SetActive(false);
        displayMenu.SetActive(true);
    }

    public void LanguageMenu()
    {
        optionsMenu.SetActive(false);
        languageMenu.SetActive(true);
    }

    public void SettingsMenu()
    {
        optionsMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ControlsMenu()
    {
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void CreditsMenu()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MenuBack()
    {
        optionsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        languageMenu.SetActive(false);
        displayMenu.SetActive(false);
        settingsMenu.SetActive(false);
        menuMovement.currentGroup = 1;
        menuMovement.curCordinate = Vector2.zero;
    }

    public void Changed(int num)
    {
        switch (num)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 3:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
        }
    }
}