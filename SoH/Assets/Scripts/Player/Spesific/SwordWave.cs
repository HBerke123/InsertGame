using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWave : MonoBehaviour
{
    public float maxyscale;
    public float minyscale;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    void Update()
    {
        this.transform.localScale = new Vector3(0.5f, minyscale + maxyscale * (Time.time - th), 1);
    }
}
