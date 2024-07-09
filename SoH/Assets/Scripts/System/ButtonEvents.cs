using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public SceneManagment sceneM;
    public GameObject saves;
    public GameObject menu;

    public void ResumeGame()
    {
        sceneM.curscenenum = 0;
        sceneM.LoadScene();
    }

    public void NewGame()
    {
        menu.SetActive(false);
        saves.SetActive(true);
    }

    public void ExitGame() => Application.Quit();

    public void Savef1()
    {
        ResumeGame();
    }

    public void Savef2()
    {
        ResumeGame();
    }

    public void Savef3()
    {
        ResumeGame();
    }
}