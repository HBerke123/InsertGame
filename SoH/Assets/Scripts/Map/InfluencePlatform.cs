using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluencePlatform : MonoBehaviour
{
    public GameObject sound;
    public float cooldown;
    public float soundSpeed;
    float th;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
        {
            th = 0;
        }
    }

    public void SendSound(int direction)
    {
        if (th == 0)
        {
            th = Time.time;
            GameObject SBox = Instantiate(sound, this.transform.position, Quaternion.identity);
            SBox.GetComponent<Rigidbody2D>().velocity = direction * soundSpeed * Vector2.right;
        }
    }
}