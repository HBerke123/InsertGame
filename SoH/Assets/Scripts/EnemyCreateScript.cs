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
    
    
    // Start is called before the first frame update
    void Start()
    {
        EnemyPrefab = GameObject.Find("Enemy Prefab");
        Enemy1 = Instantiate(EnemyPrefab, new Vector3(165f, 0f, 0f), transform.rotation);
        Enemy2 = Instantiate(EnemyPrefab, new Vector3(170f, 0f, 0f), transform.rotation);
        Enemy3 = Instantiate(EnemyPrefab, new Vector3(175f, 0f, 0f), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
             
    }
}
