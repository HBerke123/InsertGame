using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashforce;
    public float optime;
    public float cooldown = 3;
    public bool dashable = true;
    public GameObject arrow;
    Rigidbody2D rb;
    Movement mv;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        mv = this.GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && dashable)
        {
            arrow.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if ((arrow.transform.localRotation.eulerAngles.x > 45) && (90 >= arrow.transform.localRotation.eulerAngles.x))
            {
                rb.velocity = new Vector2(rb.velocity.x, -dashforce);
            }
            else if (arrow.transform.localRotation.eulerAngles.y == 90)
            {
                StartCoroutine(Optimeover(1));
            }
            else if (arrow.transform.localRotation.eulerAngles.y == 270)
            {
                StartCoroutine(Optimeover(-1));
            }
        }
    }

    IEnumerator Optimeover(int rotation)
    {
        this.gameObject.layer = 3;
        mv.jumpable = false;
        mv.extraspeed += dashforce * rotation;
        dashable = false;
        mv.moveable = false;
        mv.extracondition = true;
        yield return new WaitForSeconds(0.125f);
        this.gameObject.layer = 0;
        if (rotation == 1) mv.extraspeed -= dashforce;
        else mv.extraspeed += dashforce;
        dashable = true;
        mv.extracondition = false;
        mv.moveable = true;
        mv.jumpable = true;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        dashable = false;
        yield return new WaitForSeconds(cooldown);
        dashable = true;
    }
}
