using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Bar cdbar;
    public PrimaryItems pItems; 
    public Vector3 Swordhboxp;
    public Vector3 Spearhboxp;
    public Vector3 Hammerhboxp;
    public Vector3 Swordhboxs;
    public Vector3 Spearhboxs;
    public Vector3 Hammerhboxs;
    public bool ready = true;
    public int[] loops = {1, 3, 6};
    BoxCollider2D bcol;

    private void Start()
    {
        bcol = this.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (pItems.itemEquipped != "Gun"))
        {
            ready = false; 

            if (this.transform.position.x <= Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                Swordhboxp = new Vector3(Mathf.Abs(Swordhboxp.x), Swordhboxp.y, 0);
                Spearhboxp = new Vector3(Mathf.Abs(Spearhboxp.x), Spearhboxp.y, 0);
                Hammerhboxp = new Vector3(Mathf.Abs(Hammerhboxp.x), Hammerhboxp.y, 0);
            }
            else
            {
                Swordhboxp = new Vector3(-Mathf.Abs(Swordhboxp.x), Swordhboxp.y, 0);
                Spearhboxp = new Vector3(-Mathf.Abs(Spearhboxp.x), Spearhboxp.y, 0);
                Hammerhboxp = new Vector3(-Mathf.Abs(Hammerhboxp.x), Hammerhboxp.y, 0);
            }

            if (pItems.itemEquipped == "Sword")
            {
                bcol.offset = Swordhboxp;
                bcol.size = Swordhboxs;
            }
            else if (pItems.itemEquipped == "Hammer")
            {
                bcol.offset = Hammerhboxp;
                bcol.size = Hammerhboxs;
            }
            else if (pItems.itemEquipped == "Spear")
            {
                bcol.offset = Spearhboxp;
                bcol.size = Spearhboxs;
            }

            bcol.enabled = true;

            StartCoroutine(Release(pItems.itemEquipped));
        }
    }

    IEnumerator Release(string itemname)
    {
        if (itemname == "Spear")
        {
            cdbar.maxValue = loops[0] * 2;
            for (int i = 0; i < loops[0]; i++)
            {
                cdbar.curValue = i;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (itemname == "Sword")
        {
            cdbar.maxValue = loops[1];
            for (int i = 0; i < loops[1]; i++)
            {
                cdbar.curValue = i;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (itemname == "Hammer")
        {
            cdbar.maxValue = loops[2];
            for (int i = 0; i < loops[2]; i++)
            {
                cdbar.curValue = i;
                yield return new WaitForSeconds(0.5f);
            }
        }
        
        ready = true;
        bcol.enabled = false;
    }
}
