using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEvent : MonoBehaviour
{
    public int areaNum;
    public GameObject platform;
    public GameObject secondPlatform;
    public GameObject thirdPlatform;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (areaNum == 0)
            {
                platform.transform.position = new Vector3(101, 2, 0);
                platform.transform.localScale = new Vector3(6, 8, 1);
                platform.GetComponent<BoxCollider2D>().enabled = enabled;
            }
            else if (areaNum == 1)
            {
                Destroy(platform);
                player.GetComponent<BlocksOnObject>().fallBlock = true;
            }
            else if (areaNum == 2)
            {
                player.GetComponent<BlocksOnObject>().fallBlock = true;
            }
            else if (areaNum == 3) 
            {
                Destroy(platform);
                secondPlatform.SetActive(true);
            }
            else if (areaNum == 4)
            {
                Destroy(platform);
                secondPlatform.SetActive(true);
                thirdPlatform.SetActive(true);
            }
            else if (areaNum == 5)
            {
                platform.SetActive(true);
            }

            Destroy(this.gameObject);
        }
    }
}
