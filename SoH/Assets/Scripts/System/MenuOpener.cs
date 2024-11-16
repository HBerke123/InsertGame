using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public bool isMenuOpen;
    public GameObject menu;
    public TimeControlStop timeControlStop;

    GamepadControls gamepadControls;
    bool pressed;

    private void Start() => gamepadControls = GetComponent<GamepadControls>();

    private void Update()
    {
        if (gamepadControls.pause.IsPressed() && !pressed)
        {
            pressed = true;

            if (isMenuOpen) Resume();
            else
            {
                timeControlStop.StartSlowMotion();
                menu.SetActive(true);
                isMenuOpen = true;
            }
        }

        if (!gamepadControls.pause.IsPressed()) pressed = false;
    }

    public void Resume()
    {
        timeControlStop.StopSlowMotion();
        isMenuOpen = false;
        menu.SetActive(false);
    }
}