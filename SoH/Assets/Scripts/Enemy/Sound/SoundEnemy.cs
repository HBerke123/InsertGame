using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    public GroundDetection climbUp;
    public GroundDetection climbDown;
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
    public bool first;
    float baseSpeed;
    float th;

    private void Start()
    {
        baseSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (((player.GetComponent<MakeSound>().totalSoundTime > 0) || this.GetComponent<Notice>().isNoticed) && (this.GetComponent<ForcesOnObject>().Force.x == 0) && (Time.time - th > attackFrequency) && (th != 0) && first)
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

        if ((((Mathf.Abs(distanceX) < moveRangeX) && (player.GetComponent<MakeSound>().totalSoundTime > 0)) || this.GetComponent<Notice>().isNoticed) && (this.GetComponent<ForcesOnObject>().Force.x == 0))
        {
            if (!first && (screamHit == null))
            {
                first = true;
                Scream();
            } 

            this.GetComponent<Notice>().AddTime(noticeTime);

            if ((player.GetComponent<MakeSound>().totalSoundTime > 0) && (this.GetComponent<ForcesOnObject>().Force.x == 0) && (Mathf.Abs(distanceX) > rangeX))
            {
                if (this.GetComponent<ForcesOnObject>().Force.y != 0)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distanceX) / distanceX * -speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<ForcesOnObject>().Force.y);
                }
                else
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(distanceX) / distanceX * -speed + this.GetComponent<ForcesOnObject>().Force.x, this.GetComponent<Rigidbody2D>().velocity.y);

                    if (climbDown.detected && !climbUp.detected) 
                    {
                        this.transform.position += Vector3.up / 2;
                    }
                }
            } 
        }

        if ((th == 0) && (screamHit == null) && (this.GetComponent<ForcesOnObject>().Force.x == 0) && this.GetComponent<Notice>().isNoticed)
        {
            this.GetComponent<Notice>().AddTime(noticeTime);
            th = Time.time;
        }

        if (!this.GetComponent<Notice>().isNoticed)
        {
            first = false;
        }
    }

    void Shoot()
    {
        this.GetComponent<Notice>().AddTime(noticeTime);
        th = 0;
        GameObject SBox = Instantiate(soundWave, transform.position, Quaternion.identity);
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x) * waveSpeed, 0);
        SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
        SBox.GetComponent<ForcePlayer>().direction = Mathf.RoundToInt(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x));
    }

    void Scream()
    {
        this.GetComponent<Notice>().AddTime(noticeTime);
        th = 0;
        GameObject SBox = Instantiate(screamWave, this.transform.position, Quaternion.identity);
        SBox.GetComponent<DamagePlayer>().damageAmount = screamDamage;
        screamHit = SBox;
    }
}