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
        switch (eventNum)
        {
            case 0:
                if (eventStarted)
                {
                    if (player.GetComponentInChildren<SwordAttack>().attacking)
                    {
                        player.GetComponent<Movement>().enabled = true;
                        player.GetComponent<Jump>().enabled = true;
                        Destroy(this);
                    }
                }
                break;
            case 1:
                if (eventStarted)
                {
                    if (enemy == null)
                    {
                        Destroy(platform);
                        Destroy(this);
                    }
                }
                break;
            case 2:
                if (eventStarted)
                {
                    if (th == 0)
                    {
                        th = Time.time;
                    }
                }
                break;
            case 3:
                if (eventStarted)
                {
                    Destroy(platform);
                }
                break;
        }
    }
}