using UnityEngine;

public class CopyBody : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            Destroy(this);
        }
    }
}
