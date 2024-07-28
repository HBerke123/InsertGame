using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float maxFrequency;
    public float maxTime;
    public float maxShakeForce;
    float lastRandom;
    float fth;
    float th;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > maxTime))
        {
            maxTime = 0;
            maxFrequency = 0;
            th = 0;
            fth = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if (th != 0)
        {
            if (Time.time - fth > maxFrequency)
            {
                fth = Time.time;
                Shake();
            }
        }
    }

    public void StartShake(float frequency, float time, float force)
    {
        maxFrequency = Mathf.Max(maxFrequency, frequency);
        maxTime = Mathf.Max(maxTime, time);
        maxShakeForce = Mathf.Max(maxShakeForce, force);
        th = Time.time;
    }

    void Shake()
    {
        float randomPos;

        if (Random.Range(0, 2) == 0)
        {
            randomPos = Random.Range(maxShakeForce * 1 / 5, maxShakeForce * 4 / 5);
        }
        else
        {
            randomPos = Random.Range(-maxShakeForce * 4 / 5, -maxShakeForce * 1 / 5);
        }

        if (lastRandom != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(lastRandom, -lastRandom / Mathf.Abs(lastRandom) * (maxShakeForce - Mathf.Abs(lastRandom))) * -2;
            lastRandom = 0;
        }
        else
        {
            lastRandom = randomPos;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(randomPos, -randomPos / Mathf.Abs(randomPos) * (maxShakeForce - Mathf.Abs(randomPos)));
        }
    }
}
