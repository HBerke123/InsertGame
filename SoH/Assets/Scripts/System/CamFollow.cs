using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new(0, 2, -10);
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}