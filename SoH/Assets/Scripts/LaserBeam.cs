using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    BoxCollider2D laserCollider;
    SpriteRenderer laserImage;
    public bool isLaserOn;
    public float timetoStart;
    public float laserTime;
    public HealthDrainage hpdrain;
    void Start()
    {
        laserCollider = GetComponent<BoxCollider2D>();
        laserImage = GetComponent<SpriteRenderer>();
        isLaserOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLaserOn == false)
        {
            laserCollider.enabled = false;
            laserImage.enabled = false;
            StartCoroutine(StartLaser());
        }
        else if(isLaserOn == true)
        {
            laserCollider.enabled = true;
            laserImage.enabled = true;
        }    
    }
    IEnumerator StartLaser()
    {
        yield return new WaitForSeconds(timetoStart);
        isLaserOn = true;
        yield return new WaitForSeconds(laserTime);
        isLaserOn = false;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        {
            if (collider.tag == "Player")
            {
                hpdrain.TakeDamage(15.0f);
                if (hpdrain.health <= 0)
                {
                    hpdrain.health = hpdrain.maxHealth;
                    this.transform.position = new Vector3(0f, 0f, 0f);
                    hpdrain.UpdateHealthBar(hpdrain.health / hpdrain.maxHealth);
                }
            }
        }
    }


}
