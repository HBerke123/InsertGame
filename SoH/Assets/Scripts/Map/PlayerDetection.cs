using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool detected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detected = false;
        }
    }

    private void Update()
    {
        if (detected)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().riding = transform.parent.gameObject;
        }
    }
}