using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingObjects : MonoBehaviour
{
    Dash dash;
    Slide slide;
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
        dash = player.GetComponent<Dash>();
        slide = player.GetComponent<Slide>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((dash.dashing == true) || (slide.sliding == true)) Destroy(this.gameObject);
    }
}
