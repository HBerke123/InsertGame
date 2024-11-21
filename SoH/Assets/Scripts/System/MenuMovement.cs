using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMovement : MonoBehaviour
{
    public List<ButtonSelected> buttonCoordinates = new();
    public MenuOpener menuOpener;
    public Vector2 curCordinate;
    public float waitTime;
    public int currentGroup;

    GamepadControls gamepadControls;
    float th;
    bool pressed;
    bool openable;

    private void Start() => gamepadControls = GetComponent<GamepadControls>();

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > waitTime)) th = 0;
    }

    private void Update()
    {
        if (menuOpener == null) openable = true;
        else if (menuOpener.isMenuOpen) openable = true;
        else openable = false;

        for (int i = 0; i < buttonCoordinates.Count; i++)
        {
            if ((buttonCoordinates[i].buttonCordinate == curCordinate) && (buttonCoordinates[i].buttonGroup == currentGroup)) buttonCoordinates[i].selected = true;
            else buttonCoordinates[i].selected = false;
        }

        if ((th == 0) && openable)
        {
            th = Time.time;

            for (int i = 0; i < buttonCoordinates.Count; i++)
            {
                if (buttonCoordinates[i].buttonGroup == currentGroup)
                {
                    if ((gamepadControls.menuDirection == 0) && (buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.up))
                    {
                        curCordinate += Vector2.up;
                        break;
                    }
                    else if ((gamepadControls.menuDirection == 1) && (buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.right))
                    {
                        curCordinate += Vector2.right;
                        break;
                    }
                    else if ((gamepadControls.menuDirection == 2) && (buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.down))
                    {
                        curCordinate += Vector2.down;
                        break;
                    }
                    else if ((gamepadControls.menuDirection == 3) && (buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.left))
                    {
                        curCordinate += Vector2.left;
                        break;
                    }
                }
            }
        }
   
        if (gamepadControls.menuDirection == 0) th = 0;

        for (int i = 0; i < buttonCoordinates.Count; i++)
        {
            if (gamepadControls.accept.IsPressed() && !pressed && buttonCoordinates[i].selected)
            {
                pressed = true;
                buttonCoordinates[i].GetComponent<Button>().onClick.Invoke();
            }

            if (!gamepadControls.accept.IsPressed()) pressed = false;
        }
    }
}