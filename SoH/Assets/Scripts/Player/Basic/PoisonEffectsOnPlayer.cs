using UnityEngine;

public class PoisonEffectsOnPlayer : MonoBehaviour
{
    public float damageMultiplier;
    public float goodEffectTime;
    public float badEffectTime;
    public float damageFrequency;
    public float damageAmount;
    public float healFrequency;
    public float healAmount;
    public float gainCeFrequency;
    public float gainCeAmount;
    public float updateFrequency;
    public float th;

    Bar goodBar;
    Bar badBar;
    float gth;
    float bth;
    float dth;
    float hth;
    float gcth;

    private void Awake()
    {
        goodBar = GameObject.FindGameObjectWithTag("GoodBar").GetComponent<Bar>();
        badBar = GameObject.FindGameObjectWithTag("BadBar").GetComponent<Bar>();
    }

    private void FixedUpdate()
    {
        if ((dth != 0) && (Time.time - dth > damageFrequency) && (badEffectTime > 0))
        {
            dth = Time.time;
            GetComponent<HealthDrainage>().TakeDamage(damageAmount, 1);
        }

        if ((dth == 0) && (badEffectTime > 0)) dth = Time.time;

        if ((hth != 0) && (Time.time - hth > healFrequency) && (goodEffectTime > 0))
        {
            hth = Time.time;
            GetComponent<HealthDrainage>().Heal(healAmount);
        }

        if ((gcth != 0) && (Time.time - gcth > gainCeFrequency) && (goodEffectTime > 0))
        {
            gcth = Time.time;
            GetComponent<CEDrainage>().GainCE(gainCeAmount);
        }

        if ((bth != 0) && (Time.time - bth > badEffectTime) && (badEffectTime > 0))
        {
            bth = 0;
            badEffectTime = 0;
            badBar.maxValue = 0;
            badBar.curValue = 0;
        }

        if ((gth != 0) && (Time.time - gth > goodEffectTime) && (goodEffectTime > 0))
        {
            goodBar.maxValue = 0;
            goodBar.curValue = 0;
            gth = 0;
            goodEffectTime = 0;
        }

        if ((gcth == 0) && (goodEffectTime > 0)) gcth = Time.time;

        if ((hth == 0) && (goodEffectTime > 0)) hth = Time.time;

        if ((gth == 0) && (goodEffectTime > 0))
        {
            gth = Time.time;
            goodBar.maxValue = goodEffectTime;
        }

        if ((bth == 0) && (badEffectTime > 0))
        {
            bth = Time.time;
            badBar.maxValue = badEffectTime;
        }

        if (((badEffectTime > 0) || (goodEffectTime > 0)) && (th == 0)) th = Time.time;
        else if ((badEffectTime == 0) && (goodEffectTime == 0)) th = 0;

        if ((th != 0) && (Time.time - th > updateFrequency))
        {
            th = Time.time;
            goodBar.curValue = goodEffectTime - (Time.time - gth);
            badBar.curValue = badEffectTime - (Time.time - bth);
        }
    }

    public void AddGoodTime(float amount)
    {
        gth = 0;
        goodEffectTime = Mathf.Max(amount, goodEffectTime);
    }

    public void AddBadTime(float amount)
    {
        bth = 0;
        badEffectTime = Mathf.Max(amount, badEffectTime);
    }
}