using UnityEngine;

public class CrouchingDetection : MonoBehaviour
{
    public bool isSafe;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("EnemyWeapon") && !collision.CompareTag("EnemyScream") && !collision.CompareTag("EnemySound") && !collision.CompareTag("LaserTrigger") && !collision.CompareTag("Detector"))
        {
            isSafe = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSafe = true;
    }
}