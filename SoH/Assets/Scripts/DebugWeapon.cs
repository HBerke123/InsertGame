using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWeapon : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (this.GetComponentInParent<BoxCollider2D>().enabled)
        {
            this.transform.localPosition = this.GetComponentInParent<BoxCollider2D>().offset;
            this.transform.localScale = this.GetComponentInParent<BoxCollider2D>().size;
        }
        else
        {
            this.transform.localScale = Vector3.zero;
        }
    }
}
