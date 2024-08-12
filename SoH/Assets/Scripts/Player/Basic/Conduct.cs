using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conduct : MonoBehaviour
{
    public List<float> conductTimes = new();
    public Vector3 start;
    public Vector3 end;
    public float startedTime;
    public bool isPlayer;

    private void Update()
    {
        if (conductTimes.Count != 0)
        {
            if (isPlayer)
            {
                this.GetComponent<Movement>().stick = true;
                this.GetComponent<Jump>().stick = true;
            }

            if (Time.time > conductTimes[0])
            {
                this.transform.position = Vector3.Lerp(start, end, (conductTimes[0] - startedTime) / (conductTimes[conductTimes.Count - 1] - startedTime)); 

                if (isPlayer)
                {
                    this.transform.position += Vector3.down * this.GetComponent<BoxCollider2D>().size.y / 2;
                }

                conductTimes.RemoveAt(0);
            }

            if (conductTimes.Count == 0)
            {
                start = Vector3.zero;
                end = Vector3.zero;
                startedTime = 0;

                if (isPlayer)
                {
                    this.GetComponent<Movement>().stick = false;
                    this.GetComponent<Jump>().stick = false;
                }
            }
        }
    }
}