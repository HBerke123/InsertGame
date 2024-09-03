using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    GameObject player;
    HealthDrainage hpdrain;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hpdrain = player.GetComponent<HealthDrainage>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.GetComponent<Dash>().dashing)
        {
            hpdrain.TakeDamage(15);
        }
    }
}
