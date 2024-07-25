using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreBombGroup : MonoBehaviour
{
    public GameObject[] PreBombs;
    public GameObject arrow;
    public bool showing;

    public void ShowGroup()
    {
        arrow.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (arrow.transform.localRotation.eulerAngles.y < 180)
        {
            this.transform.localScale = Vector3.one;
            this.transform.localRotation = Quaternion.Euler(0, 0, -arrow.transform.localRotation.eulerAngles.x);
        }
        else
        {
            this.transform.localScale = Vector3.one - Vector3.right * 2;
            this.transform.localRotation = Quaternion.Euler(0, 0, arrow.transform.localRotation.eulerAngles.x);
        }
    }

    private void Update()
    {
        if (showing)
        {
            ShowGroup();
        }
    }
}
