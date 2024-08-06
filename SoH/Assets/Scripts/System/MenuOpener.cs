using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public bool isMenuOpen;
    public GameObject menu;
    public TimeControlStop timeControlStop;
    GamepadControls gamepadControls;
    bool pressed;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.Escape) || gamepadControls.pause) && !pressed)
        {
            pressed = true;

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

        if (Input.GetKeyUp(KeyCode.Escape) || !gamepadControls.pause)
        {
            pressed = false;
        }
    }

    public void Resume()
    {
        timeControlStop.StopSlowMotion();
        isMenuOpen = false;
        menu.SetActive(false);
    }
}
