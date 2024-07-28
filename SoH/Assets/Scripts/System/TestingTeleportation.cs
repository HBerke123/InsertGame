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
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[0];
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[1];

                if (enemies[0] != null)
                {
                    enemies[0].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[2];

                if (enemies[1] != null)
                {
                    enemies[1].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F4))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[3];

                if (enemies[2] != null)
                {
                    enemies[2].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F5))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[4];

                if (enemies[3] != null)
                {
                    enemies[3].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F6))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[5];

                if (enemies[4] != null)
                {
                    enemies[4].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F7))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[6];

                if (enemies[5] != null)
                {
                    enemies[5].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F8))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[7];

                if (enemies[6] != null)
                {
                    enemies[6].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F9))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[8];

                if (enemies[7] != null)
                {
                    enemies[7].SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F10))
            {
                foreach (GameObject gameObject in enemies)
                {
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                    }
                }

                this.transform.position = locations[9];

                if (enemies[8] != null)
                {
                    enemies[8].SetActive(true);
                }
            }
        }
    }
}