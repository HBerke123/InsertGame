using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    MenuOpener mo;

    private void Start()
    {
        mo = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<MenuOpener>();
    }

    private void Update()
    {
        if (mo.isMenuOpen)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
