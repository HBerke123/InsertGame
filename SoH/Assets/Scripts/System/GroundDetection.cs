using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool detected = false;
    public List<GameObject> grounds = new();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            detected = true;

            if (!grounds.Contains(collision.gameObject)) 
            {
                grounds.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            detected = false;
            grounds.Remove(collision.gameObject);
        }
    }
}