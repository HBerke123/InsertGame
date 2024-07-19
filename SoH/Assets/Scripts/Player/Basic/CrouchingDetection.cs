using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingDetection : MonoBehaviour
{
    public bool isSafe;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            isSafe = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSafe = true;
    }
}
