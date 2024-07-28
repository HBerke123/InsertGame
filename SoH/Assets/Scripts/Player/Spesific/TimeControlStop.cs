using UnityEngine;

public class TimeControlStop : MonoBehaviour
{
    [Header("TimeControllerSettings")]
    public float TimeScale;

    private float StartTimeScale;
    private float StartFixedDeltaTime;


    void Start()
    {
        StartTimeScale = Time.timeScale;
        StartFixedDeltaTime = Time.fixedDeltaTime;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartSlowMotion();
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            StopSlowMotion();
        }
    }

    public void StartSlowMotion()
    {
        Time.timeScale = TimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;
    }

    public void StopSlowMotion()
    {
        Time.timeScale = StartTimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime;
    }
}
