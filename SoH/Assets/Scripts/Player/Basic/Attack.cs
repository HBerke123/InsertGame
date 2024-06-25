using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackcooldown;
    public float attacktime;
    public float ceregaintime = 1;
    public int cecost = 10;
    bool attackable = true;
    int attacknum;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && attackable) {
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
        else if (Input.GetMouseButtonDown(1) && attackable)
        {
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
    }

    IEnumerator Attackend()
    {
        yield return new WaitForSeconds(attacktime + attacknum * attacktime);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackcooldown + attacknum * attackcooldown);
        attackable = true;
    }

    IEnumerator RegainCE(int gaincount)
    {
        for (int i = 0; i < gaincount; i++) { 
            yield return new WaitForSeconds(ceregaintime / 10);
            this.GetComponentInParent<CEDrainage>().GainCE(1);
        }
    }
}