using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public float slideforce;
    public float optime;
    public bool slideable = true;
    Rigidbody2D rb;
    Movement mv;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        mv = this.GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && slideable && mv.grounded)
        {
            if (rb.velocity.x >= 8)
            {
                StartCoroutine(Optimeover(1));
            }
            else if (rb.velocity.x <= -8)
            {
                StartCoroutine(Optimeover(-1));
            }
        }
    }

    IEnumerator Optimeover(int rotation)
    {
        this.gameObject.layer = 3;
        mv.jumpable = false;
        mv.extraspeed += slideforce * rotation;
        slideable = false;
        mv.moveable = false;
        mv.extracondition = true;
        yield return new WaitForSeconds(0.25f);
        this.gameObject.layer = 0;
        if (rotation == 1) mv.extraspeed -= slideforce;
        else mv.extraspeed += slideforce;
        slideable = true;
        mv.extracondition = false;
        mv.moveable = true;
        mv.jumpable = true;
    }
}
