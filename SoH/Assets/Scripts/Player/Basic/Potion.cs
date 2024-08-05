using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float drinkTime;
    public float healAmount;
    public float cEAmount;
    public bool hasPotion;
    public bool drinking;
    float th;
    HealthDrainage hd;
    CEDrainage ced;
    SwordAttack sa;
    SoundUse su;
    ScreamUse su2;
    GunShot gs;
    BlocksOnObject boo;
    Animator a;
    Crouching c;

    private void Start()
    {
        c = this.GetComponent<Crouching>();
        a = this.GetComponent<Animator>();
        boo = this.GetComponent<BlocksOnObject>();
        gs = this.GetComponentInChildren<GunShot>();
        su2 = this.GetComponentInChildren<ScreamUse>();
        su = this.GetComponentInChildren<SoundUse>();
        sa = this.GetComponentInChildren<SwordAttack>();
        ced = this.GetComponent<CEDrainage>();
        hd = this.GetComponent<HealthDrainage>();
    }

    private void FixedUpdate()
    {
        if ((Time.time - th > drinkTime) && drinking)
        {
            drinking = false;
            a.SetBool("Drinking", false);
        }
    }

    private void Update()
    {
        if (hasPotion && Input.GetKey(KeyCode.F) && !drinking && !sa.ready && !su.started && !su2.screaming && !gs.started && !boo.isBlocked && !c.isCrouching)
        {
            a.SetBool("Drinking", true);
            drinking = true;
            ced.GainCE(cEAmount);
            hd.Heal(healAmount);
            hasPotion = false;
            th = Time.time;
        }
        else if (hasPotion && Input.GetKey(KeyCode.F) && !drinking && !sa.ready && !su.started && !su2.screaming && !gs.started && !boo.isBlocked)
        {
            c.Crouch();
        }
    }
}
