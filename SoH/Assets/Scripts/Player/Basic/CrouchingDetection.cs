using UnityEngine;

public class CrouchingDetection : MonoBehaviour
{
    public bool isSafe;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.GetComponent<Collider2D>().isTrigger && (collision.CompareTag("Grounds") || collision.CompareTag("Platform"))) isSafe = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSafe = true;
    }
}