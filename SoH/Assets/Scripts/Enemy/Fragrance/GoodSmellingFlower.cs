using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSmellingFlower : MonoBehaviour
{
    GameObject player;
    public GameObject goodSmoke;
    public float range;
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
            Smell();
            th = 0;
        }
    }

    private void Update()
    {

    }

    void Smell()
    {

    }
}
