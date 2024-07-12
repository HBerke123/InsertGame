using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamUse : MonoBehaviour
{
    public GameObject ScreamWave;
    public float damage;
    public float cooldown;
    GameObject screamHit;
    float th;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (th == 0))
        {
            Scream();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Destroy(screamHit);
        }

        if (screamHit != null)
        {
            this.GetComponentInParent<Movement>().screaming = true;
        }
        else
        {
            this.GetComponentInParent<Movement>().screaming = false;
        }
    }

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > cooldown))
        {
            th = 0;
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
