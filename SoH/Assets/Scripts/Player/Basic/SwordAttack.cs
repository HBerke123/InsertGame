using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SwordAttack : MonoBehaviour
{
    readonly List<float> reloadTimes = new(); 
    public MenuOpener menuOpener;
    public float soundTime;
    public float attackDamage;
    public float skillAttackDamage;
    public float attackCooldown;
    public float skillAttackCooldown;
    public float attackTime;
    public float skillAttackTime;
    public float cERegainTime;
    public float skillCERegainTime;
    public float skillholdtime;
    public float noticeTime;
    public float delayTime;
    public float skillDelayTime;
    public int cECost;
    public int skillCECost;
    float th = 0;
    public bool ready;
    bool attackable = true;
    int attacknum;

    private void FixedUpdate()
    {
        if (Time.time - th > skillholdtime)
        {
            th = 0;
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

    private void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            if (attackable && !this.GetComponent<GunShot>().started && !this.GetComponent<SoundUse>().started && !this.GetComponent<ScreamUse>().screaming && !this.GetComponentInParent<BlocksOnObject>().isBlocked && this.GetComponentInParent<Crouching>().GetComponentInChildren<CrouchingDetection>().isSafe)
            {
                if (Input.GetMouseButtonDown(0) && attackable)
                {
                    this.GetComponentInParent<Crouching>().UnCrouch();
                    ready = true;
                    th = Time.time;
                }
                else if (((th == 0) || (Input.GetMouseButtonUp(0))) & ready)
                {
                    ready = false;

                    if (th != 0)
                    {
                        this.GetComponentInParent<MakeSound>().AddTime(soundTime);

                        attackable = false;
                        attacknum = 0;
                        this.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1);

                        if (this.GetComponentInParent<SpriteRenderer>().flipX) this.transform.localScale = new Vector3(-1, 1, 1);
                        else this.transform.localScale = new Vector3(1, 1, 1);

                        this.GetComponentInParent<CEDrainage>().LoseCE(cECost);
                        this.GetComponentInParent<CEProduce>().delayAmount = Mathf.Max(this.GetComponentInParent<CEProduce>().delayAmount, delayTime);
                        this.GetComponent<BoxCollider2D>().enabled = true;

                        for (int i = 1; i < cECost + 1; i++)
                        {
                            reloadTimes.Add(Time.time + cERegainTime / cECost * i);
                        }

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

                        this.GetComponentInParent<CEDrainage>().LoseCE(skillCECost);
                        this.GetComponentInParent<CEProduce>().delayAmount = Mathf.Max(this.GetComponentInParent<CEProduce>().delayAmount, skillDelayTime);

                        for (int i = 1; i < skillCECost + 1; i++)
                        {
                            reloadTimes.Add(Time.time + skillCERegainTime / skillCECost * i);
                        }

                        StartCoroutine(Attackend());
                        StartCoroutine(Cooldown());
                    }
                }
            }
        }
    }

    IEnumerator Attackend()
    {
        if (attacknum == 0)
        {
            yield return new WaitForSecondsRealtime(attackTime);
        }
        else
        {
            yield return new WaitForSecondsRealtime(skillAttackTime);
        }
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator Cooldown()
    {
        if (attacknum == 0)
        {
            yield return new WaitForSecondsRealtime(attackCooldown);
        }
        else
        {
            yield return new WaitForSecondsRealtime(skillAttackCooldown);
        }
        attackable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (attacknum == 0)
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(attackDamage);
                collision.GetComponent<Notice>().noticeTime = Mathf.Max(collision.GetComponent<Notice>().noticeTime, noticeTime);
            }
            else
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(skillAttackDamage);
                collision.GetComponent<Notice>().noticeTime = Mathf.Max(collision.GetComponent<Notice>().noticeTime, noticeTime);
            }
        }
    }
}