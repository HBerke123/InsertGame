using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public bool isLaserTrigered = false;
    public SpriteRenderer sr;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isLaserTrigered = true;
            sr.enabled = true;
        
        }
        
}
private void OnTriggerExit2D(Collider2D other)
{
     if (other.gameObject.CompareTag("Player"))
        {
           isLaserTrigered = false;
           sr.enabled = false;
        
        }
        
}
}
