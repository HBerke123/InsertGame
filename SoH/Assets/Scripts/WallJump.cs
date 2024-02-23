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
    private void Start()
    {
        mv = this.GetComponent<Movement>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hold == false)
        {
            LayerMask mask = LayerMask.GetMask("Ground");

            Vector3 location = new Vector3(transform.position.x - 0.75f, transform.position.y + 0.5f, 0);
            RaycastHit2D hit = Physics2D.Raycast(location, Vector3.down, 1, mask);
            location = new Vector3(transform.position.x + 0.75f, transform.position.y + 0.5f, 0);
            RaycastHit2D hit2 = Physics2D.Raycast(location, Vector3.down, 1, mask);


            if (hit.collider != null)
            {
                mv.extracondition[1] = true;
                rotation = -1;
                hold = true;
            }     
            else if (hit2.collider != null)
            {
                mv.extracondition[1] = true;
                rotation = 1;
                hold = true;
            }
        }
    }

    public IEnumerator OnLeave()
    {
        yield return new WaitForEndOfFrame();
        if (Input.GetKey(KeyCode.Space) && (Time.time - timepassed <= 1)) StartCoroutine(OnLeave());
        else if (Time.time - timepassed <= 1) 
        {
            hold = false;
            rb.gravityScale = 1;
            mv.onWallJump();
        }
        else
        {
            hold = false;
            rb.gravityScale = 1;
            mv.moveable = true;
        }
    }
}
