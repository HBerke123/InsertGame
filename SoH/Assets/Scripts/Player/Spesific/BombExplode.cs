using UnityEngine;

public class BombExplode : MonoBehaviour
{
    /*public float damageAmount;
    public float TotalTime;
    public GameObject SoundWave;
    GameObject player;
    bool explosed;
    float th;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        th = Time.time;
    }

    private void Update()
    {
        if (Time.time - th > TotalTime)
        {
            Explode();
        }
    }

    public void Explode()
    {
        if (!explosed)
        {
            explosed = true;
            player.GetComponentInChildren<GunShot>().lastBombs.Remove(this.gameObject);
            GameObject SBox = Instantiate(SoundWave, this.transform.position, new Quaternion(0, 0, 0, 0));
            SBox.GetComponent<DamageEnemies>().damageAmount = damageAmount;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
        }
    }*/
}