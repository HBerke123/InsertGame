using UnityEngine;
using UnityEngine.UI;

public class ButtonSelected : MonoBehaviour
{
    Color baseColor;
    Color selectedColor;

    public Vector2 buttonCordinate;
    public bool selected;
    public int buttonGroup;

    private void Start()
    {
        baseColor = GetComponent<Button>().colors.normalColor;
        selectedColor = new Color(baseColor.r / 2, baseColor.g / 2, baseColor.b / 2);
    }

    private void Update()
    {
        if (selected) GetComponent<Image>().color = selectedColor;
        else GetComponent<Image>().color = baseColor;
    }
}