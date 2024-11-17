using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool climbable;
    public bool detected;
    public List<GameObject> grounds = new();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            detected = true;

            if (!grounds.Contains(collision.gameObject)) 
            {
                grounds.Add(collision.gameObject);

                if (collision.gameObject.GetComponent<SemiSolidPlatform>() == null) climbable = true;
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