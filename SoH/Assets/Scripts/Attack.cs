using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject cdbargr;
    public Bar cdbar;
    public PrimaryItems pItems; 
    public Vector3 Swordhboxp;
    public Vector3 Spearhboxp;
    public Vector3 Hammerhboxp;
    public Vector3 Swordhboxs;
    public Vector3 Spearhboxs;
    public Vector3 Hammerhboxs;
    public Vector3 UpHammerhboxp;
    public Vector3 UpSwordhboxp;
    public Vector3 UpSpearhboxp;
    public Vector3 DownHammerhboxp;
    public Vector3 DownSwordhboxp;
    public Vector3 DownSpearhboxp;
    public bool ready = true;
    public int[] loops = {2, 6, 12};
    BoxCollider2D bcol;

    private void Start()
    {
        bcol = this.GetComponent<BoxCollider2D>();
        cdbargr.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (pItems.itemEquipped != "Gun") && ready)
        {
            ready = false; 
            Swordhboxp = new Vector3(Mathf.Abs(Swordhboxp.x), Swordhboxp.y, 0);
            Spearhboxp = new Vector3(Mathf.Abs(Spearhboxp.x), Spearhboxp.y, 0);
            Hammerhboxp = new Vector3(Mathf.Abs(Hammerhboxp.x), Hammerhboxp.y, 0);
            if (this.GetComponentInParent<SpriteRenderer>().flipX)
            {
                Swordhboxp = new Vector3(-Mathf.Abs(Swordhboxp.x), Swordhboxp.y, 0);
                Spearhboxp = new Vector3(-Mathf.Abs(Spearhboxp.x), Spearhboxp.y, 0);
                Hammerhboxp = new Vector3(-Mathf.Abs(Hammerhboxp.x), Hammerhboxp.y, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (pItems.itemEquipped == "Sword")
                {
                    bcol.offset = UpSwordhboxp;
                    bcol.size = Swordhboxs;
                }
                else if (pItems.itemEquipped == "Hammer")
                {
                    bcol.offset = UpHammerhboxp;
                    bcol.size = Hammerhboxs;
                }
                else if (pItems.itemEquipped == "Spear")
                {
                    bcol.offset = UpSpearhboxp;
                    bcol.size = Spearhboxs;
                }
            }
            else if (Input.GetKey(KeyCode.S)) {
                if (pItems.itemEquipped == "Sword")
                {
                    bcol.offset = DownSwordhboxp;
                    bcol.size = Swordhboxs;
                }
                else if (pItems.itemEquipped == "Hammer")
                {
                    bcol.offset = DownHammerhboxp;
                    bcol.size = Hammerhboxs;
                }
                else if (pItems.itemEquipped == "Spear")
                {
                    bcol.offset = DownSpearhboxp;
                    bcol.size = Spearhboxs;
                }
            }
            else
            {
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
            }
            

            bcol.enabled = true;

            if (Input.GetKey(KeyCode.Space) ||Input.GetKey(KeyCode.S)) { 
                StartCoroutine(Release(pItems.itemEquipped, true));
            }
            else
            {
                StartCoroutine(Release(pItems.itemEquipped, false));
            }
        }
    }

    IEnumerator Release(string itemname, bool istilt)
    {
        if (!istilt)
        {
            yield return new WaitForSeconds(0.125f / loops[0]);
        }
        yield return new WaitForSeconds(0.125f / loops[0]);
        bcol.enabled = false;
        cdbargr.SetActive(true);
        if (itemname == "Spear")
        {
            cdbar.maxValue = loops[0];
            for (int i = 1; i < loops[0]; i++)
            {
                cdbar.curValue = i;
                yield return new WaitForSeconds(0.25f / loops[0]);
            }
        }
        else if (itemname == "Sword")
        {
            cdbar.maxValue = loops[1];
            for (int i = 1; i < loops[1]; i++)
            {
                cdbar.curValue = i;
                yield return new WaitForSeconds(0.25f / loops[0]);
            }
        }
        else if (itemname == "Hammer")
        {
            cdbar.maxValue = loops[2];
            for (int i = 1; i < loops[2]; i++)
            {
                cdbar.curValue = i;
                yield return new WaitForSeconds(0.25f / loops[0]);
            }
        }
        
        ready = true;
        cdbargr.SetActive(false);
    }
}
