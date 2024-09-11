using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
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
            player.transform.position = new Vector3(-12.5f, 15, 0);
        }
    }
}