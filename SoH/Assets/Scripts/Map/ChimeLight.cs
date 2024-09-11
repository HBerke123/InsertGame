using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimeLight : MonoBehaviour
{
    public GameObject explosion;
    public float explodeTime;
    GameObject player;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((player.GetComponent<PickUpLight>().chimeLight == this.gameObject) && (th == 0))
        {
            th = Time.time;
        }
        else if ((player.GetComponent<PickUpLight>().chimeLight == this.gameObject) && (th != 0) && (Time.time - th > explodeTime))
        {
            this.transform.position = player.transform.position + Vector3.up * this.transform.lossyScale.y / 2;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if ((player.GetComponent<PickUpLight>().chimeLight != this.gameObject) && (th != 0))
        {
            explodeTime -= Time.time - th;
            th = 0;
        }
    }
}