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

    private void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.y - player.transform.position.y), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.x - player.transform.position.x), 2));
        if (distance < 1.45f)
        {
            if ((dash.dashing == true) || (slide.sliding == true)) Destroy(this.gameObject);
        }
    }
}
