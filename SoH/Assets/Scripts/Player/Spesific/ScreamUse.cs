using UnityEngine;
using System.Collections.Generic;

public class ScreamUse : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public GameObject ScreamWave;
    public float soundTime;
    public float damage;
    public float cooldown;
    public float loseFrequency;
    public float loseAmount;
    public float delayTime;
    public float cERegainTime;
    public bool screaming;
    GameObject screamHit;
    float th;
    float lth;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (th == 0) && !this.GetComponent<SoundUse>().started && !this.GetComponent<SwordAttack>().ready && !this.GetComponent<GunShot>().started && this.transform.parent.GetComponentInChildren<GroundDetection>().detected && !this.GetComponentInParent<BlocksOnObject>().isBlocked && this.GetComponentInParent<Crouching>().GetComponentInChildren<CrouchingDetection>().isSafe)
        {
            this.GetComponentInParent<Crouching>().UnCrouch();
            Scream();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Destroy(screamHit);
        }

        if (screamHit != null)
        {
            this.GetComponentInParent<MakeSound>().AddTime(soundTime);
            screaming = true;
        }
        else
        {
            screaming = false;
        }
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
        {
            th = 0;
        }

        if ((screamHit != null) && (Time.time - lth > loseFrequency))
        {
            this.GetComponentInParent<CEDrainage>().LoseCE(loseAmount);
            lth = Time.time;

            for (int i = 1; i < loseAmount + 1; i++)
            {
                reloadTimes.Add(Time.time + cERegainTime / loseAmount * i);
            }
        }

        for (int i = 0; i < reloadTimes.Count; i++)
        {
            if (Time.time > reloadTimes[i])
            {
                reloadTimes.RemoveAt(i);

                if (this.GetComponentInParent<CEDrainage>().cE < this.GetComponentInParent<CEDrainage>().maxCE / 2)
                {
                    this.GetComponentInParent<CEDrainage>().GainCE(1);
                }
            }
        }
    }

    public void Scream()
    {
        GameObject SBox = Instantiate(ScreamWave, this.transform.position, new Quaternion(0, 0, 0, 0));
        SBox.GetComponent<DamageEnemies>().damageAmount = damage;
        screamHit = SBox;
        th = Time.time;
    }
}
