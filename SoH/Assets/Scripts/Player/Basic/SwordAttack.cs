using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float soundTime;
    public float quickAttackDamage;
    public float heavyAttackDamage;
    public float quickAttackCooldown;
    public float heavyAttackCooldown;
    public float quickAttackTime;
    public float heavyAttackTime;
    public float ceRegainTime;
    public float skillholdtime;
    public int quickCeCost;
    public int heavyCeCost;
    public int skillCeCost;
    float th = 0;
    bool attackable = true;
    int attacknum;

    private void Update()
    {
        if (attackable && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword")) { 
            if (((Time.time - th >= skillholdtime) || (Input.GetMouseButtonUp(1))) && (th > 0))
            {
                if (Time.time - th < skillholdtime)
                {
                    this.GetComponentInParent<MakeSound>().AddTime(soundTime);
                    th = 0;
                    attackable = false;
                    attacknum = 1;
                    this.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.75f);
                        
                    if (this.GetComponentInParent<SpriteRenderer>().flipX) this.transform.localScale = new Vector3(-1, 1, 1);
                    else this.transform.localScale = new Vector3(1, 1, 1);

                    this.GetComponentInParent<CEDrainage>().LoseCE(heavyCeCost);
                    this.GetComponent<BoxCollider2D>().enabled = true;

                    StartCoroutine(RegainCE(heavyCeCost));
                    StartCoroutine(Attackend());
                    StartCoroutine(Cooldown());
                }
                else
                {
                    this.GetComponentInParent<MakeSound>().AddTime(soundTime);
                    th = 0;
                    attackable = false;
                    attacknum = 1;

                    if (this.GetComponentInParent<SpriteRenderer>().flipX) this.GetComponent<SwordSkill>().SkillStart(-1);
                    else this.GetComponent<SwordSkill>().SkillStart(1);

                    this.GetComponentInParent<CEDrainage>().LoseCE(skillCeCost);

                    StartCoroutine(RegainCE(skillCeCost));
                    StartCoroutine(Attackend());
                    StartCoroutine(Cooldown());
                }
            }
            else if (Input.GetMouseButtonDown(0) && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword")) {
                this.GetComponentInParent<MakeSound>().AddTime(soundTime);

                attackable = false;
                attacknum = 0;
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1);

                if (this.GetComponentInParent<SpriteRenderer>().flipX) this.transform.localScale = new Vector3(-1, 1, 1);
                else this.transform.localScale = new Vector3(1, 1, 1);

                this.GetComponentInParent<CEDrainage>().LoseCE(quickCeCost);
                this.GetComponent<BoxCollider2D>().enabled = true;
            
                StartCoroutine(RegainCE(quickCeCost));
                StartCoroutine(Attackend());
                StartCoroutine(Cooldown());
            }
            else if (Input.GetMouseButtonDown(1) && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword"))
            {
                th = Time.time;
            }
        }
    }

    IEnumerator Attackend()
    {
        if (attacknum == 0)
        {
            yield return new WaitForSecondsRealtime(quickAttackTime);
        }
        else
        {
            yield return new WaitForSecondsRealtime(heavyAttackTime);
        }
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator Cooldown()
    {
        if (attacknum == 0)
        {
            yield return new WaitForSecondsRealtime(quickAttackCooldown);
        }
        else
        {
            yield return new WaitForSecondsRealtime(heavyAttackCooldown);
        }
        attackable = true;
    }

    IEnumerator RegainCE(int gaincount)
    {
        for (int i = 0; i < gaincount; i++)
        {
            yield return new WaitForSecondsRealtime(ceRegainTime);
            this.GetComponentInParent<CEDrainage>().GainCE(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (attacknum == 0)
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(quickAttackDamage);
            }
            else
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(heavyAttackDamage);
            }
        }
    }
}