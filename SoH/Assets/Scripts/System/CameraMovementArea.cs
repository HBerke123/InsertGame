using UnityEngine;

public class CameraMovementArea : MonoBehaviour
{
    [SerializeField] bool incDetector;
    [SerializeField] bool lockX;
    [SerializeField] bool lockY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(Camera.main.transform))
        {
            if (lockX) 
            {
                if (incDetector)
                {
                    Camera.main.GetComponent<CamFollow>().lockIX = true;
                }
                else
                {
                    Camera.main.GetComponent<CamFollow>().lockDX = true;
                }
            }
            
            if (lockY)
            {
                if (incDetector)
                {
                    Camera.main.GetComponent<CamFollow>().lockIY = true;
                }
                else
                {
                    Camera.main.GetComponent<CamFollow>().lockDY = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(Camera.main.transform))
        {
            if (lockX)
            {
                if (incDetector)
                {
                    Camera.main.GetComponent<CamFollow>().lockIX = false;
                }
                else
                {
                    Camera.main.GetComponent<CamFollow>().lockDX = false;
                }
            }

            if (lockY)
            {
                if (incDetector)
                {
                    Camera.main.GetComponent<CamFollow>().lockIY = false;
                }
                else
                {
                    Camera.main.GetComponent<CamFollow>().lockDY = false;
                }
            }
        }
    }
}