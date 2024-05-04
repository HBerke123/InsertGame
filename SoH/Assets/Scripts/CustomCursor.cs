using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Sprite unarmedS;
    public Sprite swordS;
    public Sprite hammerS;
    public Sprite spearS;
    public Sprite gunS;
    public PrimaryItems pItems;

    private void Start()
    {
        Cursor.visible = false;
        this.GetComponent<SpriteRenderer>().sprite = unarmedS;
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        
        if (pItems.itemEquipped == "Unarmed")
        {
            this.GetComponent<SpriteRenderer>().sprite = unarmedS;
        }
        else if (pItems.itemEquipped == "Sword")
        {
            this.GetComponent<SpriteRenderer>().sprite = swordS;
        }
        else if (pItems.itemEquipped == "Hammer")
        {
            this.GetComponent<SpriteRenderer>().sprite = hammerS;
        }
        else if (pItems.itemEquipped == "Gun")
        {
            this.GetComponent<SpriteRenderer>().sprite = gunS;
        }
        else if (pItems.itemEquipped == "Spear")
        {
            this.GetComponent<SpriteRenderer>().sprite = spearS;
        }
    }
}
