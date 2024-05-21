using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryItems : MonoBehaviour
{
    public string itemEquipped = "Unarmed";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(itemEquipped == "Sword")
            {
                itemEquipped = "Unarmed";
                this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0f);
            }
            else
            {
                itemEquipped = "Sword";
                this.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemEquipped == "Gun")
            {
                itemEquipped = "Unarmed";
                this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0f);
            }
            else
            {
                itemEquipped = "Gun";
                this.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0.8f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (itemEquipped == "Hammer")
            {
                itemEquipped = "Unarmed";
                this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0f);
            }
            else
            {
                itemEquipped = "Hammer";
                this.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0.8f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (itemEquipped == "Spear")
            {
                itemEquipped = "Unarmed";
                this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0f);
            }
            else
            {
                itemEquipped = "Spear";
                this.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0.8f);
            }
        }
    }
}
