using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PrimaryItems pItems; 
    public Vector3 Swordhboxp;
    public Vector3 Spearhboxp;
    public Vector3 Hammerhboxp;
    public Vector3 Swordhboxs;
    public Vector3 Spearhboxs;
    public Vector3 Hammerhboxs;
    public bool ready = true;
    BoxCollider2D bcol;

    private void Start()
    {
        bcol = this.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ready = false;


            if (this.transform.position.x <= Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                Swordhboxs = new Vector3(Mathf.Abs(Swordhboxp.x), Swordhboxp.y, 0);
                Spearhboxs = new Vector3(Mathf.Abs(Spearhboxp.x), Spearhboxp.y, 0);
                Hammerhboxs = new Vector3(Mathf.Abs(Hammerhboxp.x), Hammerhboxp.y, 0);
            }
            else
            {
                Swordhboxs = new Vector3(-Mathf.Abs(Swordhboxp.x), Swordhboxp.y, 0);
                Spearhboxs = new Vector3(-Mathf.Abs(Spearhboxp.x), Spearhboxp.y, 0);
                Hammerhboxs = new Vector3(-Mathf.Abs(Hammerhboxp.x), Hammerhboxp.y, 0);
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
        }
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.1f);
        ready = true;
        bcol.enabled = false;
    }
}
