using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    public GameObject soundWave;
    public GameObject screamWave;
    public float soundDamage;
    public float waveSpeed;
    public float speed;
    public float moveRangex;
    public float rangex;
    public float shootFrequency;
    public float screamFrequency;
    public float screamDamage;
    GameObject player;
    GameObject screamHit;
    float baseSpeed;
    float th;
    float sth;

    private void Start()
    {
        baseSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (sth != 0) && (Time.time - sth > screamFrequency) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= rangex)
            {
                Scream();
            }
            sth = 0;
        }

        if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (sth == 0) && (th != 0) && (Time.time - th > shootFrequency) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
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

        if (screamHit != null)
        {
            speed = 0;
        }
        else
        {
            speed = baseSpeed;

            if ((sth == 0) && (Mathf.Abs(distancex) < rangex) && (player.GetComponent<MakeSound>().totalSoundTime > 0))
            {
                sth = Time.time;
            }
        }

        if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (Mathf.Abs(distancex) < moveRangex) && (Mathf.Abs(distancex) > rangex * 3 / 4) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
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
        else if (sth != 0)
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

        if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (Mathf.Abs(distancex) < rangex))
        {
            if (th == 0)
            {
                th = Time.time;
            }
        }
    }

    void Shoot()
    {
        GameObject SBox = Instantiate(soundWave, transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x) * waveSpeed, 0);
        SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
        SBox.GetComponent<ForcePlayer>().direction = (int)(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x));
    }

    void Scream()
    {
        GameObject SBox = Instantiate(screamWave, this.transform.position, Quaternion.identity);
        SBox.GetComponent<DamagePlayer>().damageAmount = screamDamage;
        screamHit = SBox;
        sth = 0;
    }
}