using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");;
    }

    private void Update()
    {
        if (((player.transform.position.y + player.transform.lossyScale.y / 2) < (this.transform.position.y - this.transform.parent.lossyScale.y / 2)) || player.GetComponent<Dash>().dashing && ((((player.transform.position.x - player.GetComponent<Dash>().dashspeed * player.GetComponent<Dash>().dashtime) < (this.transform.position.x - this.transform.lossyScale.x / 2)) && (this.transform.position.x < player.transform.position.x)) || (((player.transform.position.x + player.GetComponent<Dash>().dashspeed * player.GetComponent<Dash>().dashtime) > (this.transform.position.x + this.transform.lossyScale.x / 2)) && (player.transform.position.x < this.transform.position.x))))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (!this.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
