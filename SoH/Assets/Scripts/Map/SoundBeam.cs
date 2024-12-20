using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBeam : MonoBehaviour
{
    GameObject directionObject;
    float th;
    public float cooldown;
    public float soundDamage;
    public float waveSpeed;
    public GameObject soundWave;

    private void Start()
    {
        directionObject = this.transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
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
        float distancex = directionObject.transform.position.x - this.transform.position.x;
        float distancey = directionObject.transform.position.y - this.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(distancex, 2) + Mathf.Pow(distancey, 2));
        GameObject SBox = Instantiate(soundWave, transform.position + new Vector3(distancex / distance, distancey / distance, 0), Quaternion.identity);
        SBox.GetComponent<Rigidbody2D>().velocity = new Vector2(distancex / distance, distancey / distance) * waveSpeed;
        SBox.transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(distancex / distance) * Mathf.Rad2Deg);
        SBox.GetComponent<DamagePlayer>().damageAmount = soundDamage;

        if (Mathf.RoundToInt(distancex) == 0)
        {
            SBox.GetComponent<ForcePlayer>().direction = Mathf.RoundToInt(-distancey / Mathf.Abs(distancey)) + 1;
        }
        else
        {
            SBox.GetComponent<ForcePlayer>().direction = Mathf.RoundToInt(-distancex / Mathf.Abs(distancex)) + 2;
        }
    }
}