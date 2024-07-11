using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingWave : MonoBehaviour
{
    public float maxyscale;
    public float minyscale;
    public bool yScale;
    float xSize;
    float th;

    private void Start()
    {
        xSize = this.transform.localScale.x;
        th = Time.time;
    }

    void Update()
    {
        this.transform.localScale = new Vector3(xSize, minyscale + maxyscale * (Time.time - th), 1);
    }
}
