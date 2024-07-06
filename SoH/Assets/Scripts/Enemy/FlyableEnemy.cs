using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyableEnemy : MonoBehaviour
{
    GameObject player;
    public float flyspeed;
    public float rangex;
    public float rangey;
    public float cooldown;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
        {
            th = 0;
            ThrowThorn();
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        float distancey = this.transform.position.y - player.transform.position.y;
        if (Mathf.Abs(distancex) < rangex)
        {
            if (distancey < rangey)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, flyspeed);
            }

            if (th == 0)
            {
                th = Time.time;
            }
        }
        else
        {
            th = 0;
        }
    }

    void ThrowThorn()
    {
        Debug.Log(Vector3.Angle(this.transform.position, player.transform.position));
    }
}