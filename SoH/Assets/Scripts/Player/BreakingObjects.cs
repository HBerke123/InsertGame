using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingObjects : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        foreach (GameObject gameObject in FindObjectsOfType<GameObject>())
        {
            if (gameObject.CompareTag("Player"))
            {
                player = gameObject;
                break;
            }
        }
    }

    private void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.y - player.transform.position.y), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.x - player.transform.position.x), 2));
    }
}
