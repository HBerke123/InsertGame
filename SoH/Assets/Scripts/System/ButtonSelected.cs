using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelected : MonoBehaviour
{
    public Vector2 buttonCordinate;
    Color baseColor;
    Color selectedColor;
    GamepadControls gamepadControls;
    bool pressed;
    public bool selected;
    public int buttonGroup;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        baseColor = this.GetComponent<Button>().colors.normalColor;
        selectedColor = new Color(baseColor.r / 2, baseColor.g / 2, baseColor.b / 2);
    }

    private void Update()
    {
        if (selected)
        {
            this.GetComponent<Image>().color = selectedColor;
        }
        else
        {
            this.GetComponent<Image>().color = baseColor;
        }
    }
}