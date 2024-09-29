using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    public Vector3 location;
    public int areaNum;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void InteractObject()
    {
        if (areaNum == 0)
        {
            player.transform.position = location;
            Camera.main.transform.position = location;
        }
    }
}