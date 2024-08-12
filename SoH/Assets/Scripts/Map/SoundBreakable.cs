using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBreakable : MonoBehaviour
{
    public void Break()
    {
        Destroy(this.gameObject);
    }
}
