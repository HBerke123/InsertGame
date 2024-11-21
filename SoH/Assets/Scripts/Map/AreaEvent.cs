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
            switch (areaNum)
            {
                case 0:
                    Destroy(platform);
                    secondPlatform.GetComponent<WalkableEnemy>().rangex = 12;
                    thirdPlatform.SetActive(true);
                    collision.GetComponent<BlocksOnObject>().blockTime = 1;
                    break;
                case 1:
                    player.GetComponent<BlocksOnObject>().fallBlock = true;
                    Destroy(platform);
                    secondPlatform.GetComponent<SpecialEvent>().eventStarted = true;
                    break;
                case 2:
                    player.GetComponent<BlocksOnObject>().blockTime = Mathf.Max(1, player.GetComponent<BlocksOnObject>().blockTime);
                    Destroy(platform);
                    secondPlatform.SetActive(true);
                    break;
                case 3:
                    Destroy(platform);
                    secondPlatform.SetActive(true);
                    GameObject.FindGameObjectWithTag("GamepadController").GetComponent<SpecialEvent>().eventStarted = true;
                    break;
                case 4:
                    Destroy(platform);
                    player.GetComponent<BlocksOnObject>().fallBlock = true;
                    secondPlatform.SetActive(true);
                    thirdPlatform.SetActive(true);
                    break;
                case 5:
                    platform.SetActive(true);
                    secondPlatform.SetActive(true);
                    Destroy(thirdPlatform);
                    break;
                case 6:
                    collision.GetComponent<CheckpointRecorder>().SaveCheckpoint(location);
                    break;
                case 7:
                    collision.GetComponent<Movement>().enabled = false;
                    collision.GetComponent<Jump>().enabled = false;
                    this.GetComponentInParent<WalkableEnemy>().speed = 0;
                    this.GetComponentInParent<SpecialEvent>().eventStarted = true;
                    break;
                case 8:
                    SceneManager.LoadScene("Lysandra");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}