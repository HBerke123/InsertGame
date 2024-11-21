using UnityEngine;

public class MakeSound : MonoBehaviour
{
    public float totalSoundTime;

    float th;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > totalSoundTime))
        {
            th = 0;
            totalSoundTime = 0;
        }
    }

    public void AddTime(float amount)
    {
        th = Time.time;
        totalSoundTime = Mathf.Max(totalSoundTime, amount);
    }
}