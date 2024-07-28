using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public bool isMenuOpen;
    public GameObject menu;
    public TimeControlStop timeControlStop;

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
                timeControlStop.StartSlowMotion();
                menu.SetActive(true);
                isMenuOpen = true;
            }
        }
    }

    public void Resume()
    {
        timeControlStop.StopSlowMotion();
        isMenuOpen = false;
        menu.SetActive(false);
    }
}
