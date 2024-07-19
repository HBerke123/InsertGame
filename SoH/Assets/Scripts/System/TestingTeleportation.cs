using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTeleportation : MonoBehaviour
{
    public Vector3[] locations;
    public GameObject[] enemies;
    public MenuOpener menuOpener;

    private void Start()
    {
        foreach (GameObject gameObject in enemies)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[0];
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[1];
                enemies[0].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[2];
                enemies[1].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F4))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[3];
                enemies[2].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F5))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[4];
                enemies[3].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F6))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[5];
                enemies[4].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F7))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[6];
                enemies[5].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F8))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[7];
                enemies[6].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F9))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[8];
                enemies[7].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.F10))
            {
                foreach (GameObject gameObject in enemies)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = locations[9];
                enemies[8].SetActive(true);
            }
        }
    }
}
