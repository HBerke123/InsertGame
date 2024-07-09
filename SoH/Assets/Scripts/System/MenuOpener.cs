using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuOpener : MonoBehaviour
{
    bool isMenuOpen;
    List<GameObject> stopObjects = new List<GameObject>();
    public GameObject menu;

    private void Start()
    {
        int i = 0;
        foreach (StopInMenu stopMenu in FindObjectsOfType<StopInMenu>())
        {
            stopObjects.Add(stopMenu.gameObject);
            i++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                Resume();
            }
            else
            {
                menu.SetActive(true);
                isMenuOpen = true;
                foreach (GameObject gObject in stopObjects)
                {
                    gObject.SetActive(false);
                }
            }
        }
    }

    public void Resume()
    {
        isMenuOpen = false;
        foreach (GameObject gObject in stopObjects)
        {
            gObject.SetActive(true);
        }
        menu.SetActive(false);
    }
}
