using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryItems : MonoBehaviour
{
    public static string itemEquipped = "Unarmed";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(itemEquipped == "Sword")
            {
                Debug.Log("Unarmed");
                itemEquipped = "Unarmed";
                this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0f);
            }
            else
            {
                Debug.Log("Sword");
                itemEquipped = "Sword";
                this.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemEquipped == "Gun")
            {
                Debug.Log("Unarmed");
                itemEquipped = "Unarmed";
                this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0f);
            }
            else
            {
                Debug.Log("Gun");
                itemEquipped = "Gun";
                this.GetComponent<Renderer>().material.color = new Color(0.8f, 0f, 0.8f);
            }
        }
    }
}
