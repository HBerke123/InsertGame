using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEvent : MonoBehaviour
{
    public Vector3 location;
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
                Destroy(platform);
                secondPlatform.GetComponent<WalkableEnemy>().rangex = 12;
                thirdPlatform.SetActive(true);
                collision.GetComponent<BlocksOnObject>().blockTime = 1;
            }
            else if (areaNum == 1)
            {
                player.GetComponent<BlocksOnObject>().fallBlock = true;
                Destroy(platform);
            }
            else if (areaNum == 2)
            {
                player.GetComponent<BlocksOnObject>().blockTime = Mathf.Max(1, player.GetComponent<BlocksOnObject>().blockTime);
                Destroy(platform);
                secondPlatform.SetActive(true);
            }
            else if (areaNum == 3) 
            {
                Destroy(platform);
                secondPlatform.SetActive(true);
                GameObject.FindGameObjectWithTag("GamepadController").GetComponent<SpecialEvent>().eventStarted = true;
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
                secondPlatform.SetActive(true);
            }
            else if (areaNum == 6)
            {
                collision.GetComponent<CheckpointRecorder>().SaveCheckpoint(location);
            }
            else if (areaNum == 7)
            {
                collision.GetComponent<Movement>().enabled = false;
                collision.GetComponent<Jump>().enabled = false;
                this.GetComponentInParent<WalkableEnemy>().speed = 0;
                this.GetComponentInParent<SpecialEvent>().eventStarted = true;
            }

            Destroy(this.gameObject);
        }
    }
}