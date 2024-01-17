using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float uplimit;
    public float downlimit;
    public float speed;
    public TimeChanger time;
    int privatetime;
    bool up = true;

    private void FixedUpdate()
    {
        if ((this.transform.position.y < uplimit) && up) transform.position += Vector3.up * speed;
        else up = false;
        if ((this.transform.position.y > downlimit) && !up) transform.position += Vector3.down * speed;
        else up = true;
    }

    public int Tsc(int value) => privatetime = value;
}
