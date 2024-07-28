using UnityEngine;

public class ScreamUse : MonoBehaviour
{
    public GameObject ScreamWave;
    public float soundTime;
    public float damage;
    public float cooldown;
    public float loseFrequency;
    public float loseAmount;
    GameObject screamHit;
    float th;
    float lth;

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
            this.GetComponentInParent<MakeSound>().AddTime(soundTime);
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

        if ((screamHit != null) && (Time.time - lth > loseFrequency))
        {
            this.GetComponentInParent<CEDrainage>().LoseCE(loseAmount);
            lth = Time.time;
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
