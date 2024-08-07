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
    float gth;
    float bth;
    float dth;
    float hth;
    float gcth;

    private void FixedUpdate()
    {
        if ((dth != 0) && (Time.time - dth > damageFrequency) && (badEffectTime > 0))
        {
            dth = Time.time;
            this.GetComponent<HealthDrainage>().TakeDamage(damageAmount);
        }

        if ((dth == 0) && (badEffectTime > 0))
        {
            dth = Time.time;
        }

        if ((hth != 0) && (Time.time - hth > healFrequency) && (goodEffectTime > 0))
        {
            hth = Time.time;
            this.GetComponent<HealthDrainage>().Heal(healAmount);
        }

        if ((gcth != 0) && (Time.time - gcth > gainCeFrequency) && (goodEffectTime > 0))
        {
            gcth = Time.time;
            this.GetComponent<CEDrainage>().GainCE(gainCeAmount);
        }

        if ((bth != 0) && (Time.time - bth > badEffectTime) && (badEffectTime > 0))
        {
            bth = 0;
            badEffectTime = 0;
        }

        if ((gth != 0) && (Time.time - gth > goodEffectTime) && (goodEffectTime > 0))
        {
            this.GetComponentInChildren<SwordAttack>().attackDamage /= damageMultiplier;
            this.GetComponentInChildren<SwordAttack>().skillAttackDamage /= damageMultiplier;
            this.GetComponentInChildren<SwordSkill>().damage /= damageMultiplier;
            this.GetComponentInChildren<ScreamUse>().damage /= damageMultiplier;
            this.GetComponentInChildren<GunShot>().damage /= damageMultiplier;
            gth = 0;
            goodEffectTime = 0;
        }

        if ((gcth == 0) && (goodEffectTime > 0))
        {
            gcth = Time.time;
        }

        if ((hth == 0) && (goodEffectTime > 0))
        {
            hth = Time.time;
        }

        if ((gth == 0) && (goodEffectTime > 0))
        {
            this.GetComponentInChildren<SwordAttack>().attackDamage *= damageMultiplier;
            this.GetComponentInChildren<SwordAttack>().skillAttackDamage *= damageMultiplier;
            this.GetComponentInChildren<SwordSkill>().damage *= damageMultiplier;
            this.GetComponentInChildren<ScreamUse>().damage *= damageMultiplier;
            this.GetComponentInChildren<GunShot>().damage *= damageMultiplier;
            gth = Time.time;
        }

        if ((bth == 0) && (badEffectTime > 0))
        {
            bth = Time.time;
        }
    }
}
