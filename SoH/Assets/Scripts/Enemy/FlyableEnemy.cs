using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyableEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject arrow;
    public GameObject Thorn;
    public float thornTime;
    public float flyspeed;
    public float rangex;
    public float rangey;
    public float cooldown;
    public float thornSpeed;
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
            if (distancey < rangey * 3 / 4)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, flyspeed);
            }
            else if (distancey < rangey)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
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
        arrow.transform.LookAt(player.transform);
        GameObject SThorn = Instantiate(Thorn, this.transform.position, new Quaternion(0, 0, 0, 0));
        
        if (arrow.transform.rotation.eulerAngles.y == 270)
        {
            SThorn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos((arrow.transform.rotation.eulerAngles.x + 180) * Mathf.Deg2Rad) * thornSpeed, Mathf.Sin((arrow.transform.rotation.eulerAngles.x + 180) * Mathf.Deg2Rad) * thornSpeed);
            SThorn.transform.rotation = Quaternion.Euler(0, 0, arrow.transform.rotation.eulerAngles.x + 90);
        }
        else
        {
            SThorn.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos((arrow.transform.rotation.eulerAngles.x) * Mathf.Deg2Rad) * thornSpeed, Mathf.Sin((arrow.transform.rotation.eulerAngles.x + 180) * Mathf.Deg2Rad) * thornSpeed);
            SThorn.transform.rotation = Quaternion.Euler(0, 0, arrow.transform.rotation.eulerAngles.x + 180);
        }
        SThorn.GetComponent<SkillEnd>().TotalTime = thornTime;
    }
}