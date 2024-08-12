using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMovement : MonoBehaviour
{
    public List<ButtonSelected> buttonCoordinates = new();
    GamepadControls gamepadControls;
    public MenuOpener menuOpener;
    public Vector2 curCordinate;
    float th;
    bool pressed;
    bool openable;
    public float waitTime;
    public int currentGroup;
    
    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > waitTime))
        {
            th = 0;
        }
    }

    private void Update()
    {
        if (menuOpener == null)
        {
            openable = true;
        }
        else if (menuOpener.isMenuOpen)
        {
            openable = true;
        }
        else
        {
            openable = false;
        }

        for (int i = 0; i < buttonCoordinates.Count; i++)
        {
            if ((buttonCoordinates[i].buttonCordinate == curCordinate) && (buttonCoordinates[i].buttonGroup == currentGroup))
            {
                buttonCoordinates[i].selected = true;
            }
            else
            {
                buttonCoordinates[i].selected = false;
            }
        }

        if ((th == 0) && openable)
        {
            th = Time.time;

            if (gamepadControls.menuDirection == 0)
            {
                for (int i = 0; i < buttonCoordinates.Count; i++)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.up) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.up;
                            break;
                        }
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.left) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.left;
                            break;
                        }
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.down) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.down;
                            break;
                        }
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.right) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.right;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonCoordinates.Count; i++)
                {
                    if (gamepadControls.menuDirection == 0)
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.up) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.up;
                            break;
                        }
                    }
                    else if (gamepadControls.menuDirection == 1)
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.right) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.right;
                            break;
                        }
                    }
                    else if (gamepadControls.menuDirection == 2)
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.down) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.down;
                            break;
                        }
                    }
                    else if (gamepadControls.menuDirection == 3)
                    {
                        if ((buttonCoordinates[i].buttonCordinate == curCordinate + Vector2.left) && (buttonCoordinates[i].buttonGroup == currentGroup))
                        {
                            curCordinate = curCordinate + Vector2.left;
                            break;
                        }
                    }
                }
            }
        }
   
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && (gamepadControls.menuDirection == 0))
        {
            th = 0;
        }

        for (int i = 0; i < buttonCoordinates.Count; i++)
        {
            if ((Input.GetKey(KeyCode.Return) || gamepadControls.accept) && !pressed && buttonCoordinates[i].selected)
            {
                pressed = true;
                buttonCoordinates[i].GetComponent<Button>().onClick.Invoke();
            }

            if (!Input.GetKey(KeyCode.Return) && !gamepadControls.accept)
            {
                pressed = false;
            }
        }
    }
}