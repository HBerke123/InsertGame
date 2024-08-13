using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEvent : MonoBehaviour
{
    public int areaNum;
    public GameObject platform;
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

            Destroy(this.gameObject);
        }
    }
}
