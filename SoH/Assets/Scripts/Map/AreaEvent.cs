using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                platform.transform.position = new Vector3(101, 2, 0);
                platform.transform.localScale = new Vector3(6, 8, 1);
                platform.GetComponent<BoxCollider2D>().enabled = enabled;
                collision.GetComponent<BlocksOnObject>().blockTime = 1;
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
            else if (areaNum == 8) 
            {
                SceneManager.LoadScene("Lysandra");
            }

            Destroy(this.gameObject);
        }
    }
}