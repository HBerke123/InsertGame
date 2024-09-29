using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmellBeam : MonoBehaviour
{
    public GameObject badSmoke;
    public float cooldown;
    public bool reloadable;
    float th;
    SpriteRenderer sr;

    private void Start()
    {
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
        Instantiate(badSmoke, this.transform.position, Quaternion.identity);

        if (!reloadable)
        {
            Destroy(this.gameObject);
        }

        th = Time.time;
        sr.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((th == 0) && collision.CompareTag("Player"))
        {
            Smell();
        }
    }
}