using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvent : MonoBehaviour
{
    public int eventNum;
    public bool eventStarted;
    public GameObject enemy;
    public GameObject platform;
    GameObject player;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > 5))
        {
            platform.SetActive(true);
            Destroy(this);
        }
    }

    private void Update()
    {
        if (eventNum == 0)
        {
            if (eventStarted)
            {
                if (player.GetComponentInChildren<SwordAttack>().attacking)
                {
                    player.GetComponent<Movement>().enabled = true;
                    player.GetComponent<Jump>().enabled = true;
                    Destroy(this);
                }
            }
        }
        else if (eventNum == 1)
        {
            if (eventStarted)
            {
                if (enemy == null) 
                {
                    Destroy(platform);
                    Destroy(this);
                }
            }
        }
        else if (eventNum == 2)
        {
            if (eventStarted)
            {
                th = Time.time;
            }
        }
    }
}