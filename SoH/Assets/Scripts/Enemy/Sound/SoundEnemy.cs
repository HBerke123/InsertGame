using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    GameObject player;
    public GameObject soundWave;
    public GameObject screamWave;
    public float soundForcePower;
    public float screamForcePower;
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
        if ((th != 0) && (Time.time - th > shootFrequency) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= rangex)
            {
                Shoot();
            }
            th = 0;
        }

        if ((sth != 0) && (Time.time - sth > screamFrequency) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
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

        if ((Mathf.Abs(distancex) < moveRangex) && (Mathf.Abs(distancex) > rangex * 3 / 4) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            th = 0;
            sth = 0;
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
            SBox.GetComponent<ForcePlayer>().forceAmount = soundForcePower;
            SBox.GetComponent<ForcePlayer>().direction = -1;
        }
        else
        {
            GameObject SBox = Instantiate(soundWave, transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(waveSpeed, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = waveTime;
            SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
            SBox.GetComponent<ForcePlayer>().forceAmount = soundForcePower;
            SBox.GetComponent<ForcePlayer>().direction = 1;
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
            SBox.GetComponent<ForcePlayer>().forceAmount = screamForcePower;
            SBox.GetComponent<ForcePlayer>().direction = -1;
        }
        else
        {
            GameObject SBox = Instantiate(screamWave, transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(screamSpeed, 0);
            SBox.GetComponent<SkillEnd>().TotalTime = screamTime;
            SBox.GetComponent<DamagePlayer>().damageAmount = screamDamage;
            SBox.GetComponent<ForcePlayer>().forceAmount = screamForcePower;
            SBox.GetComponent<ForcePlayer>().direction = 1;
        }
    }
}
