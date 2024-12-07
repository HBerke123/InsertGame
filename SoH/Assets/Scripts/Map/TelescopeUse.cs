using UnityEngine;

public class TelescopeUse : MonoBehaviour
{
    [SerializeField] GameObject area;
    public bool isScoping;

    private void Update()
    {
        if (isScoping && (Camera.main.orthographicSize == 7))
        {
            Camera.main.GetComponent<CamFollow>().area = area;
            Camera.main.orthographicSize = 12;
            Camera.main.GetComponent<CamFollow>().isScoping = true;
        }
        else if (!isScoping && (Camera.main.orthographicSize == 12))
        {
            Camera.main.GetComponent<CamFollow>().isScoping = false;
            Camera.main.orthographicSize = 7;
        }
    }
}
