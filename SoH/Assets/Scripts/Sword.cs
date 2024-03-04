using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool inRange = false;
    public Collider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && inRange)
        {
            EnemyHP.enemyHealth -= 5;
            Debug.Log(EnemyHP.enemyHealth);
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            if (PrimaryItems.itemEquipped == "Sword")
            {
                inRange = true;
            }
            else
            {
                inRange = false;
            }
        }
    }
}
