using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductive : MonoBehaviour
{
    public Conductive otherEnd;
    public float arriveTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Sound"))
        {
            if (collision.GetComponent<Conduct>().conductTimes.Count == 0)
            {
                for (int i = 1; i < (arriveTime / 0.01f) + 1; i++)
                {
                    collision.GetComponent<Conduct>().conductTimes.Add(Time.time + arriveTime / 100 * i);
                }

                collision.GetComponent<Conduct>().start = this.transform.position;
                collision.GetComponent<Conduct>().end = otherEnd.transform.position;
                collision.GetComponent<Conduct>().startedTime = Time.time;
            }
        }
    }
}