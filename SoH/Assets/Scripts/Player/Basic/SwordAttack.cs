using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float attackcooldown;
    public float attacktime;
    public float ceregaintime;
    public float skillholdtime;
    public int cecost;
    float th = 0;
    bool attackable = true;
    int attacknum;

    private void Update()
    {
        if (attackable && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword")) { 
            if (((Time.time - th >= skillholdtime) || (Input.GetMouseButtonUp(1) || Input.GetKeyDown(KeyCode.Joystick1Button10))) && (th > 0))
            {
                if (Time.time - th < skillholdtime)
                {
                    th = 0;
                    attackable = false;
                    attacknum = 1;
                    this.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 0.75f);
                        
                    if (this.GetComponentInParent<SpriteRenderer>().flipX) this.transform.localScale = new Vector3(-1, 1, 1);
                    else this.transform.localScale = new Vector3(1, 1, 1);

                    this.GetComponentInParent<CEDrainage>().LoseCE(cecost * 2);
                    this.GetComponent<BoxCollider2D>().enabled = true;

                    StartCoroutine(RegainCE(cecost * 2));
                    StartCoroutine(Attackend());
                    StartCoroutine(Cooldown());
                }
                else
                {
                    th = 0;
                    attackable = false;
                    attacknum = 1;

                    if (this.GetComponentInParent<SpriteRenderer>().flipX) this.GetComponent<SwordSkill>().SkillStart(-1);
                    else this.GetComponent<SwordSkill>().SkillStart(1);

                    this.GetComponentInParent<CEDrainage>().LoseCE(cecost * 4);

                    StartCoroutine(RegainCE(cecost * 4));
                    StartCoroutine(Attackend());
                    StartCoroutine(Cooldown());
                }
            }
            else if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button11)) && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword")) {
                attackable = false;
                attacknum = 0;
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1);

                if (this.GetComponentInParent<SpriteRenderer>().flipX) this.transform.localScale = new Vector3(-1, 1, 1);
                else this.transform.localScale = new Vector3(1, 1, 1);

                this.GetComponentInParent<CEDrainage>().LoseCE(cecost);
                this.GetComponent<BoxCollider2D>().enabled = true;
            
                StartCoroutine(RegainCE(cecost));
                StartCoroutine(Attackend());
                StartCoroutine(Cooldown());
            }
            else if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Joystick1Button10)) && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Sword"))
            {
                th = Time.time;
            }
        }
    }

    IEnumerator Attackend()
    {
        yield return new WaitForSecondsRealtime(attacktime + attacknum * attacktime);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(attackcooldown + attacknum * attackcooldown);
        attackable = true;
    }

    IEnumerator RegainCE(int gaincount)
    {
        for (int i = 0; i < gaincount; i++) { 
            yield return new WaitForSecondsRealtime(ceregaintime / cecost);
            this.GetComponentInParent<CEDrainage>().GainCE(1);
        }
    }
}