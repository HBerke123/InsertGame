using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    Movement mv;
    Rigidbody2D rb;
    public int rotation;
    public float timepassed;
    public bool hold;
    public LayerMask mask;
    private void Start()
    {
        mv = this.GetComponent<Movement>();
        rb = this.GetComponent<Rigidbody2D>();
        mask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        if (hold == false)
        {
            Vector3 location = new(transform.position.x - 0.75f, transform.position.y + 0.5f, 0);
            RaycastHit2D hit = Physics2D.Raycast(location, Vector3.down, 1, mask);
            location = new(transform.position.x + 0.75f, transform.position.y + 0.5f, 0);
            RaycastHit2D hit2 = Physics2D.Raycast(location, Vector3.down, 1, mask);


            if (hit.collider != null)
            {
                mv.extracondition[1] = true;
                rotation = -1;
            }     
            else if (hit2.collider != null)
            {
                mv.extracondition[1] = true;
                rotation = 1;
            }
            else mv.extracondition[1] = false;
        }
    }

    public IEnumerator OnLeave()
    {
        hold = true;
        Vector3 location = new(transform.position.x - 0.75f, transform.position.y + 0.5f, 0);
        RaycastHit2D hit = Physics2D.Raycast(location, Vector3.down, 1, mask);
        location = new(transform.position.x + 0.75f, transform.position.y + 0.5f, 0);
        RaycastHit2D hit2 = Physics2D.Raycast(location, Vector3.down, 1, mask);


        if ((hit.collider != null) || (hit2.collider != null))
        {
            mv.extracondition[1] = true;
        }

        yield return new WaitForEndOfFrame();
        if (Input.GetKey(KeyCode.Space) && (Time.time - timepassed <= 1) && mv.extracondition[1]) StartCoroutine(OnLeave());
        else if ((Time.time - timepassed <= 1) && mv.extracondition[1]) 
        {
            hold = false;
            rb.gravityScale = 1;
            mv.OnWallJump();
        }
        else
        {
            hold = false;
            rb.gravityScale = 1;
            mv.moveable = true;
            mv.extracondition[1] = false;
        }
    }
}
