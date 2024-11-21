using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningTrigger : MonoBehaviour
{
    public void Turn()
    {
        this.transform.parent.eulerAngles = this.transform.parent.eulerAngles + Vector3.forward * 90;
    }
}
