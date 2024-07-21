using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject lightWave;
    public float lightDamage;
    public float waveSpeed;
    public float speed;
    public float moveRangex;
    public float rangex;
    public float shootFrequency;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((Time.time - th > shootFrequency) && (th != 0) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= rangex)
            {
                Shoot();
            }
            th = 0;
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;
        
        if ((Mathf.Abs(distancex) < moveRangex) && (Mathf.Abs(distancex) > rangex * 3 / 4) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            th = 0;
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distancex) / distancex * -speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distancex) / distancex * -speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            if (this.GetComponent<ForcesOnObject>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        if (Mathf.Abs(distancex) < rangex) 
        {
            if (th == 0)
            {
                th = Time.time;
            }
        }
    }

    void Shoot()
    {
        GameObject SBox = Instantiate(lightWave, transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x) * waveSpeed, 0);
        SBox.GetComponent<DamagePlayer>().damageAmount = lightDamage;
    }
}
