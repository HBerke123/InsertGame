using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreBombGroup : MonoBehaviour
{
    public List<GameObject> preBombs = new();
    public GameObject arrow;
    public bool showing;

    public void ShowGroup()
    {
        arrow.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if ((arrow.transform.localRotation.eulerAngles.y < 180) && !this.GetComponentInParent<SpriteRenderer>().flipX)
        {
            this.transform.localScale = Vector3.one;
            this.transform.localRotation = Quaternion.Euler(0, 0, -arrow.transform.localRotation.eulerAngles.x);
        }
        else if ((arrow.transform.localRotation.eulerAngles.y > 180) && this.GetComponentInParent<SpriteRenderer>().flipX)
        {
            this.transform.localScale = Vector3.one - Vector3.right * 2;
            this.transform.localRotation = Quaternion.Euler(0, 0, arrow.transform.localRotation.eulerAngles.x);
        }
    }

    public void SetBomb(GameObject bomb)
    {
        preBombs.Add(bomb);
    }

    private void Update()
    {
        if (showing)
        {
            ShowGroup();
        }
    }
}
