using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public int enemyHP = 100;
    public SpriteRenderer spriteRenderer;
    public GameObject EnemyPrefab;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public GameObject Enemy8;
    public GameObject Enemy9;
    public GameObject Enemy10;
    public float collisionTime;
    void Start()
    {
        EnemyPrefab = GameObject.Find("Enemy Prefab");

        Enemy1 = Instantiate(EnemyPrefab, new Vector3(165f, 0f, 0f), transform.rotation);
        Enemy2 = Instantiate(EnemyPrefab, new Vector3(170f, 0f, 0f), transform.rotation);
        Enemy3 = Instantiate(EnemyPrefab, new Vector3(175f, 0f, 0f), transform.rotation);
        Enemy4 = Instantiate(EnemyPrefab, new Vector3(165f, 1f, 0f), transform.rotation);
        Enemy5 = Instantiate(EnemyPrefab, new Vector3(170f, 1f, 0f), transform.rotation);
        Enemy6 = Instantiate(EnemyPrefab, new Vector3(175f, 1f, 0f), transform.rotation);
        Enemy7 = Instantiate(EnemyPrefab, new Vector3(165f, 2f, 0f), transform.rotation);
        Enemy8 = Instantiate(EnemyPrefab, new Vector3(170f, 2f, 0f), transform.rotation);
        Enemy9 = Instantiate(EnemyPrefab, new Vector3(175f, 2f, 0f), transform.rotation);
        Enemy10 = Instantiate(EnemyPrefab, new Vector3(175f, 3f, 0f), transform.rotation);
    }
    void Update()
    {
        Debug.Log(collisionTime);
    }
    void OnCollisionEnter(Collider target)
    {
        if (target.gameObject.tag.Equals("Enemy") == true)
        {
            collisionTime = Time.time;
            
        }
    }
}