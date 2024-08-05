using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    GameObject player;
    bool changable;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");;
    }

    private void Update()
    {
        if (player.GetComponent<Dash>().dashing && ((((player.transform.position.x - player.GetComponent<Dash>().dashspeed * player.GetComponent<Dash>().dashtime) < (this.transform.position.x - this.transform.lossyScale.x / 2)) && (this.transform.position.x < player.transform.position.x)) || (((player.transform.position.x + player.GetComponent<Dash>().dashspeed * player.GetComponent<Dash>().dashtime) > (this.transform.position.x + this.transform.lossyScale.x / 2)) && (player.transform.position.x < this.transform.position.x))))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (!this.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
