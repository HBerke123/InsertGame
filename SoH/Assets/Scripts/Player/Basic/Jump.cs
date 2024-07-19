using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public MenuOpener menuOpener;
    public bool screaming;
    public bool stick;
    public float soundTime;
    public float jumpforce = 8;
    public float jumptime = 2;
    float maxspeed = 0;
    float stime = 0;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            if (Input.GetKeyDown(KeyCode.Space) && this.GetComponentInChildren<GroundDetection>().detected && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && !this.GetComponentInChildren<Crouching>().isCrouching)
            {
                this.GetComponent<MakeSound>().AddTime(soundTime);
                stime = Time.time;
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.Space) && (Time.time - stime < jumptime) && !stick && !screaming) 
            {
                if (rb.velocity.y > maxspeed)
                {
                    maxspeed = rb.velocity.y;
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, maxspeed * jumptime - (Time.time - stime ));
                }
            }
        }

 
    }
}
