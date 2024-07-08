using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject soundWave;
    public GameObject screamWave;
    public float soundDamage;
    public float screamDamage;
    public float waveSpeed;
    public float waveTime;
    public float screamSpeed;
    public float screamTime;
    public float speed;
    public float moveRangex;
    public float rangex;
    public float shootFrequency;
    public float screamFrequency;
    float th;
    float sth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > shootFrequency) && (this.GetComponent<ForcesOnEnemy>().Force.x == 0))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= rangex)
            {
                Shoot();
            }
            th = 0;
        }

        if ((sth != 0) && (Time.time - sth > screamFrequency) && (this.GetComponent<ForcesOnEnemy>().Force.x == 0))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= rangex)
            {
                Scream();
            }
            sth = 0;
        }
    }

    private void Update()
    {
        float distancex = this.transform.position.x - player.transform.position.x;

        if ((Mathf.Abs(distancex) < moveRangex) && (Mathf.Abs(distancex) > rangex * 3 / 4) && (this.GetComponent<ForcesOnEnemy>().Force.x == 0))
        {
            th = 0;
            sth = 0;
            if (this.GetComponent<ForcesOnEnemy>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distancex) / distancex * -speed + this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<ForcesOnEnemy>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distancex) / distancex * -speed + this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        else
        {
            if (this.GetComponent<ForcesOnEnemy>().Force.y != 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<ForcesOnEnemy>().Force.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<ForcesOnEnemy>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        if (Mathf.Abs(distancex) < rangex)
        {
            if (th == 0)
            {
                th = Time.time;
            }

            if (sth == 0)
            {
                sth = Time.time;
            }
        }
    }

    void Shoot()
    {
        if (this.transform.position.x >= player.transform.position.x)
        {
            GameObject SBox = Instantiate(soundWave, transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-waveSpeed, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = waveTime;
            SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
        }
        else
        {
            GameObject SBox = Instantiate(soundWave, transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(waveSpeed, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = waveTime;
            SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
        }
    }

    void Scream()
    {
        if (this.transform.position.x >= player.transform.position.x)
        {
            GameObject SBox = Instantiate(screamWave, transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-screamSpeed, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = screamTime;
            SBox.GetComponent<DamagePlayer>().damageAmount = screamDamage;
        }
        else
        {
            GameObject SBox = Instantiate(screamWave, transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(screamSpeed, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = screamTime;
            SBox.GetComponent<DamagePlayer>().damageAmount = screamDamage;
        }
    }
}
