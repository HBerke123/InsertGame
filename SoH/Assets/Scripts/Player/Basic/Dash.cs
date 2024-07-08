using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashspeed = 8;
    public float dashcooldown = 0.5f;
    public float dashtime = 0.1f;
    public bool dashable = true;
    public bool stick = false;
    public int cecost = 50;
    Movement mv;

    private void Start()
    {
        mv = this.GetComponent<Movement>();
    }

    private void Update()
    {
        if (dashable && Input.GetKeyDown(KeyCode.LeftControl) && !stick)
        {
            this.GetComponent<CEDrainage>().LoseCE(cecost);
            dashable = false;
            mv.dashing = true;
            if (this.GetComponent<SpriteRenderer>().flipX) mv.dspeed = -dashspeed;
            else mv.dspeed = dashspeed;
            StartCoroutine(Dashend());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Dashend()
    {
        yield return new WaitForSecondsRealtime(dashtime);
        mv.dspeed = 0;
        mv.dashing = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(dashcooldown);
        dashable = true;
    }
}
