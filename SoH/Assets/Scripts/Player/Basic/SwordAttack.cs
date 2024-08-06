using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SwordAttack : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public List<AudioClip> swordSounds = new();
    public MenuOpener menuOpener;
    public float soundTime;
    public float attackDamage;
    public float skillAttackDamage;
    public float attackCooldown;
    public float skillAttackCooldown;
    public float attackTime;
    public float lastAttackTime;
    public float skillAttackTime;
    public float cERegainTime;
    public float skillCERegainTime;
    public float skillholdtime;
    public float noticeTime;
    public float delayTime;
    public float skillDelayTime;
    public int cECost;
    public int skillCECost;
    public bool ready;
    public bool attacking;
    bool attackable = true;
    public float totalTime;
    float cth;
    float ath;
    public float th;
    int attackNum;
    int comboNum;
    GamepadControls gamepadControls;
    AudioSource as1;
    CEDrainage ced;
    GunShot gs;
    SoundUse su;
    ScreamUse su2;
    BlocksOnObject boo;
    Crouching c;
    MakeSound ms;
    Potion p;
    BoxCollider2D bc;
    CEProduce cep;
    SwordSkill ss;
    SpriteRenderer sp;
    Animator a;
    CrouchingDetection cd;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        as1 = this.GetComponentInParent<AudioSource>();
        a = this.GetComponentInParent<Animator>();
        sp = this.GetComponentInParent<SpriteRenderer>();
        ss = this.GetComponent<SwordSkill>();
        cep = this.GetComponentInParent<CEProduce>();
        bc = this.GetComponent<BoxCollider2D>();
        p = this.GetComponentInParent<Potion>();
        ms = this.GetComponentInParent<MakeSound>();
        c = this.GetComponentInParent<Crouching>();
        boo = this.GetComponentInParent<BlocksOnObject>();
        su2 = this.GetComponent<ScreamUse>();
        su = this.GetComponent<SoundUse>();
        gs = this.GetComponent<GunShot>();
        ced = this.GetComponentInParent<CEDrainage>();
        cd = c.GetComponentInChildren<CrouchingDetection>();
    }

    private void FixedUpdate()
    {
        if ((cth != 0) && ((((attackNum == 0) || (attackNum == 2)) && (Time.time - cth > attackCooldown)) || ((attackNum == 1) && (Time.time - cth > skillAttackCooldown))))
        {
            attackable = true;
        }

        if ((ath != 0) && (((attackNum == 0) && (Time.time - ath > attackTime)) || ((attackNum == 1) && (Time.time - ath > skillAttackTime)) || ((attackNum == 2) && (Time.time - ath > lastAttackTime))))
        {
            a.SetBool("Attacking", false);
            bc.enabled = false;
            attacking = false;
        }

        if (Time.time - th > skillholdtime)
        {
            th = 0;
        }

        for (int i = 0; i < reloadTimes.Count; i++) 
        {
            if (Time.time > reloadTimes[i])
            {
                reloadTimes.RemoveAt(i);

                if (ced.cE < ced.maxCE / 2)
                {
                    ced.GainCE(1);
                }
            }
        }
    }

    private void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            if (attackable && !gs.started && !su.started && !su2.screaming && !boo.isBlocked && !c.isCrouching && !p.drinking && !attacking)
            {
                if ((Input.GetMouseButton(0) || gamepadControls.swordAttack) && (th == 0) && (totalTime == 0))
                {
                    ready = true;
                    th = Time.time;
                }
                else if (((th == 0) || (Input.GetMouseButtonUp(0) || !gamepadControls.swordAttack)) & ready)
                {
                    if (totalTime == 0)
                    {
                        totalTime = Time.time - th;
                    }

                    attacking = true;
                    ready = false;

                    if (totalTime < skillholdtime)
                    {
                        as1.PlayOneShot(swordSounds[comboNum]);
                        ms.AddTime(soundTime);
                        a.SetInteger("AttackNum", comboNum);
                        a.SetBool("Attacking", true);
                        comboNum++;
                        attackable = false;
                        attackNum = 0;

                        if (comboNum > 2)
                        {
                            comboNum = 0;
                            attackNum = 2;
                        }

                        if (sp.flipX) this.transform.localScale = new Vector3(-1, 1, 1);
                        else this.transform.localScale = new Vector3(1, 1, 1);

                        ced.LoseCE(cECost);
                        cep.delayAmount = Mathf.Max(cep.delayAmount, delayTime);
                        bc.enabled = true;

                        for (int i = 1; i < cECost + 1; i++)
                        {
                            reloadTimes.Add(Time.time + cERegainTime / cECost * i);
                        }

                        ath = Time.time;
                        cth = Time.time;
                        totalTime = 0;
                    }
                    else
                    {
                        as1.PlayOneShot(swordSounds[2]);
                        ms.AddTime(soundTime);
                        a.SetInteger("AttackNum", 2);
                        a.SetBool("Attacking", true);
                        th = 0;
                        attackable = false;
                        attackNum = 1;
                        comboNum = 0;

                        if (sp.flipX) ss.SkillStart(-1);
                        else ss.SkillStart(1);

                        ced.LoseCE(skillCECost);
                        cep.delayAmount = Mathf.Max(cep.delayAmount, skillDelayTime);

                        for (int i = 1; i < skillCECost + 1; i++)
                        {
                            reloadTimes.Add(Time.time + skillCERegainTime / skillCECost * i);
                        }

                        ath = Time.time;
                        cth = Time.time;
                        totalTime = 0;
                    }
                }
            }
            else if (attackable && !gs.started && !su.started && !su2.screaming && !boo.isBlocked && cd.isSafe && !p.drinking && !attacking)
            {
                if ((Input.GetMouseButton(0) || gamepadControls.swordAttack) && (th == 0) && (totalTime == 0))
                {
                    c.Crouch();
                    ready = true;
                    th = Time.time;
                }
                else if ((Input.GetMouseButton(0) || gamepadControls.swordAttack || (th == 0)) && ready)
                {
                    totalTime = Time.time - th;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (attackNum == 0)
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(attackDamage);
            }
            else if (attackNum == 1)
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(skillAttackDamage);
            }
            else
            {
                collision.GetComponent<HealthDrainageOnEnemy>().LoseHealth(attackDamage);
            }

            collision.GetComponent<Notice>().noticeTime = Mathf.Max(collision.GetComponent<Notice>().noticeTime, noticeTime);
        }
    }
}