using UnityEngine;

public class TimeHolder : MonoBehaviour
{
    public float th;
    private void Start()
    {
        th = Time.time;
    }
}