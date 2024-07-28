using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public bool isLaserTrigered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isLaserTrigered = true;
        }
        else
        {
            isLaserTrigered = false;
        }
    }
}
