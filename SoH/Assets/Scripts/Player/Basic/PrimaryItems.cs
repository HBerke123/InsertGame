using UnityEngine;

public class PrimaryItems : MonoBehaviour
{
    public string itemEquipped = "Sword";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (itemEquipped == "Sword")
            {
                itemEquipped = "Unarmed";
            }
            else
            {
                itemEquipped = "Sword";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemEquipped == "Gun")
            {
                itemEquipped = "Unarmed";
            }
            else
            {
                itemEquipped = "Gun";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (itemEquipped == "Hammer")
            {
                itemEquipped = "Unarmed";
            }
            else
            {
                itemEquipped = "Hammer";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (itemEquipped == "Spear")
            {
                itemEquipped = "Unarmed";
            }
            else
            {
                itemEquipped = "Spear";
            }
        }
    }
}