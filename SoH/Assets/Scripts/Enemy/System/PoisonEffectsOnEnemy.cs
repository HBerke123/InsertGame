using UnityEngine;

public class PoisonEffectsOnEnemy : MonoBehaviour
{
    public int enemyNum;
    public float damageMultiplier;
    public float effectTime;
    public float healFrequency;
    public float healAmount;
    float th;
    float hth;

    private void FixedUpdate()
    {
        if ((th != 0) && (Time.time - th > effectTime))
        {
            effectTime = 0;
            th = 0;
            if (enemyNum == 0)
            {
                this.GetComponent<FlyingEnemy>().thornDamage /= damageMultiplier;
            }
            else if (enemyNum == 1)
            {
                this.GetComponent<ReptileEnemy>().attackDamage /= damageMultiplier;
            }
            else if (enemyNum == 2)
            {
                this.GetComponent<WalkableEnemy>().attackDamage /= damageMultiplier;
            }
            else if (enemyNum == 3)
            {
                this.GetComponent<LightEnemy>().lightDamage /= damageMultiplier;
            }
            else if (enemyNum == 4)
            {
                this.GetComponent<SoundEnemy>().screamDamage /= damageMultiplier;
            }
        }

        if ((th == 0) && (effectTime > 0))
        {
            if (enemyNum == 0)
            {
                this.GetComponent<FlyingEnemy>().thornDamage *= damageMultiplier;
            }
            else if (enemyNum == 1)
            {
                this.GetComponent<ReptileEnemy>().attackDamage *= damageMultiplier;
            }
            else if (enemyNum == 2)
            {
                this.GetComponent<WalkableEnemy>().attackDamage *= damageMultiplier;
            }
            else if (enemyNum == 3)
            {
                this.GetComponent<LightEnemy>().lightDamage *= damageMultiplier;
            }
            else if (enemyNum == 4)
            {
                this.GetComponent<SoundEnemy>().screamDamage *= damageMultiplier;
            }
            th = Time.time;
        }

        if ((hth != 0) && (Time.time - hth > healFrequency))
        {
            this.GetComponent<HealthDrainageOnEnemy>().GainHealth(healAmount);
            hth = 0;
        }

        if ((hth == 0) && (effectTime > 0))
        {
            hth = Time.time;
        }
    }
}