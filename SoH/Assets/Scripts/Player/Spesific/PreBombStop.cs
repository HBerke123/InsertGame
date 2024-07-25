using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreBombStop : MonoBehaviour
{
    public float totalTime;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - th > totalTime)
        {
            Destroy(this.GetComponent<Rigidbody2D>());
            Destroy(this);
        }
    }
}