using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmellBeam : MonoBehaviour
{
    public GameObject badSmoke;
    public float range;
    public float cooldown;
    float distance;
    float th;
    GameObject player;
    SpriteRenderer sr;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
        {
            th = 0;
            sr.enabled = true;
        }
    }

    public void Smell()
    {
        Instantiate(badSmoke, this.transform.position, new Quaternion(0, 0, 0, 0));
        th = Time.time;
        sr.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((distance <= range) && (th == 0) && collision.CompareTag("Player"))
        {
            Smell();
        }
    }
}
