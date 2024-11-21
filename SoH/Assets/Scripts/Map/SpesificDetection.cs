using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpesificDetection : MonoBehaviour
{
    public Collider2D spesific;
    public bool detected;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == spesific)
        {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == spesific)
        {
            detected = false;
        }
    }
}
