using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public List<bool> extracondition = new List<bool>();
    public float extraspeed;
    public float speed;
    public float jumpforce;
    public float walljumpforce;
    public bool jumpable;
    public bool moveable = true;
    public bool grounded;
    Rigidbody2D rb;
    WallJump wj;
    public float CheckRadius = Mathf.Sqrt(2);
    public LayerMask layerMask;
    public PrimaryItems pItems;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        wj = this.GetComponent<WallJump>();
        for (int i = 0; i < 2; i++) extracondition.Add(false);
    }

    private void Update()
    {
        if (moveable)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 20;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 10;
            }
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal") + extraspeed, rb.velocity.y);
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                this.transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal") * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
        }
        else if (extracondition[0]) {
            rb.velocity = new Vector2(extraspeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (rb.velocity.y <= jumpforce / rb.mass) && jumpable)
        {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                grounded = false;
            }   
            else if (extracondition[1])
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.gravityScale = 0;
                moveable = false;
                wj.timepassed = Time.time;
                StartCoroutine(wj.OnLeave());
            }
        }

        Vector2 location = new Vector2(transform.position.x - 0.75f, transform.position.y - 2);
        RaycastHit2D hit = Physics2D.Raycast(location, Vector2.right, 1);
        Debug.DrawRay(location, Vector2.right);

        if ((hit.collider != null) && (hit.collider.tag != "Player")) grounded = true;
        else grounded = false;
    }

    IEnumerator Jumpend(int rotation)
    {
        yield return new WaitForSeconds(0.1f);
        moveable = true;
        extracondition[0] = false;
        extraspeed -= walljumpforce / 8 * rotation;
    }

    public void onWallJump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * walljumpforce, ForceMode2D.Impulse);
        extraspeed += walljumpforce / 8 * -wj.rotation;
        extracondition[1] = false;
        extracondition[0] = true;
        moveable = false;
        StartCoroutine(Jumpend(-wj.rotation));
    }
}