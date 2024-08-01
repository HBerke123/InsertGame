using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    public GameObject soundWave;
    public GameObject screamWave;
    public float soundDamage;
    public float waveSpeed;
    public float speed;
    public float moveRangeX;
    public float rangeX;
    public float screamRange;
    public float attackFrequency;
    public float screamDamage;
    public float noticeTime;
    GameObject player;
    GameObject screamHit;
    float baseSpeed;
    float th;

    private void Start()
    {
        baseSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (this.GetComponent<ForcesOnObject>().Force.x == 0) && (Time.time - th > attackFrequency))
        {
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < screamRange) 
            {
                Scream();
            }
            else
            {
                Shoot();
            }
        }
    }

    private void Update()
    {
        float distanceX = this.transform.position.x - player.transform.position.x;

        if (screamHit != null)
        {
            speed = 0;
        }
        else
        {
            speed = baseSpeed;
        }

        if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && ((Mathf.Abs(distanceX) < moveRangeX) || this.GetComponent<Notice>().isNoticed) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            this.GetComponent<Notice>().noticeTime = Mathf.Max(this.GetComponent<Notice>().noticeTime, noticeTime);
            if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (Mathf.Abs(distanceX) < rangeX) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
            {
                if (this.GetComponent<ForcesOnObject>().Force.y != 0)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distanceX) / distanceX * -speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
                }
                else
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distanceX) / distanceX * -speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);
                }
            }

            if ((th == 0) && (screamHit == null))
            {
                th = Time.time;
            }
        }
    }

    void Shoot()
    {
        th = 0;
        GameObject SBox = Instantiate(soundWave, transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x) * waveSpeed, 0);
        SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
        SBox.GetComponent<ForcePlayer>().direction = (int)(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x));
    }

    void Scream()
    {
        th = 0;
        GameObject SBox = Instantiate(screamWave, this.transform.position, Quaternion.identity);
        SBox.GetComponent<DamagePlayer>().damageAmount = screamDamage;
        screamHit = SBox;
    }
}