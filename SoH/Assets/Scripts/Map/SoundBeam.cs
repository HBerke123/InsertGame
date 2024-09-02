using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBeam : MonoBehaviour
{
    float th;
    public float soundDamage;
    public float waveSpeed;
    GameObject player;
    public GameObject soundWave;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > 3))
        {
            th = 0;
            Shoot();
        }

        if ((th == 0) && this.GetComponentInChildren<SoundTrigger>().isSoundTrigered)
        {
            th = Time.time;
        }
    }
    void Shoot()
    {
        GameObject SBox = Instantiate(soundWave, transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x) * waveSpeed, 0);
        SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;
        SBox.GetComponent<ForcePlayer>().direction = (int)(-(this.transform.position.x - player.transform.position.x) / Mathf.Abs(this.transform.position.x - player.transform.position.x));
    }
}
