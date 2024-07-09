using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public float damageAmount;
    public float forcePower;
    public float TotalTime;
    public float minsize;
    public float maxsize;
    public float ttime;
    public GameObject SoundWave;
    float th;

    private void Start()
    {
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
        GameObject SBox = Instantiate(SoundWave, this.transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<SkillEnd>().TotalTime = ttime;
        SBox.GetComponent<BombSoundWave>().minsize = minsize;
        SBox.GetComponent<BombSoundWave>().maxsize = maxsize;
        SBox.GetComponent<ForceEnemies>().forcePower = forcePower;
        SBox.GetComponent<DamageEnemies>().damageAmount = damageAmount;
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
        }
    }
}
