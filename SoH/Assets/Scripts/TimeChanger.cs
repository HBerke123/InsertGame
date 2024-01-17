using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{
    public int timevalue = 1;
    public GameObject[] gameObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            foreach (GameObject Item in gameObjects)
            {
                Item.GetComponent<TimeSource>().Tchanger(timevalue);
            }
        }
    }

    public IEnumerator Goback()
    {
        timevalue = -1;
        yield return new WaitForSeconds(2f);
        timevalue = 1;
    }
}
