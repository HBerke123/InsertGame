using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public SceneManagment SceneM;
    public SaveManagment SaveM;
    public GameObject Saves;
    public GameObject Menu;

    public void ResumeGame()
    {
        SceneM.curscenenum = 0;
        SceneM.LoadScene();
    }

    public void NewGame()
    {
        Menu.SetActive(false);
        Saves.SetActive(true);
    }

    public void ExitGame() => Application.Quit();

    public void Savef1()
    {
        SaveM.Fsave(1);
        ResumeGame();
    }

    public void Savef2()
    {
        SaveM.Fsave(2);
        ResumeGame();
    }

    public void Savef3()
    {
        SaveM.Fsave(3);
        ResumeGame();
    }
}