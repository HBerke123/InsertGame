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
                GetComponent<Movement>().stick = true;
                GetComponent<Jump>().stick = true;
            }

            if (Time.time > conductTimes[0])
            {
                transform.position = Vector3.Lerp(start, end, (conductTimes[0] - startedTime) / (conductTimes[^1] - startedTime)); 

                if (isPlayer) transform.position += Vector3.down * GetComponent<BoxCollider2D>().size.y / 2;

                conductTimes.RemoveAt(0);
            }

            if (conductTimes.Count == 0)
            {
                start = Vector3.zero;
                end = Vector3.zero;
                startedTime = 0;

                if (isPlayer)
                {
                    GetComponent<Movement>().stick = false;
                    GetComponent<Jump>().stick = false;
                }
            }
        }
    }
}