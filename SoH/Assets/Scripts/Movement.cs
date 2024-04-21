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

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        wj = this.GetComponent<WallJump>();
        for (int i = 0; i < 2; i++) extracondition.Add(false);
        this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0);
    }

    private void Update()
    {
        if (moveable)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 20;
                if(PrimaryItems.itemEquipped == "Unarmed") {
                    this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0);
                }
                else if (PrimaryItems.itemEquipped == "Sword")
                {
                    this.GetComponent<Renderer>().material.color = new Color(1.0f, 0, 0);
                }
                else if (PrimaryItems.itemEquipped == "Gun")
                {
                    this.GetComponent<Renderer>().material.color = new Color(1.0f, 0, 1.0f);
                }

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 10;
                if (PrimaryItems.itemEquipped == "Unarmed")
                {
                    this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0);
                }
                else if (PrimaryItems.itemEquipped == "Sword")
                {
                    this.GetComponent<Renderer>().material.color = new Color(0.8f, 0, 0);
                }
                else if (PrimaryItems.itemEquipped == "Gun")
                {
                    this.GetComponent<Renderer>().material.color = new Color(0.8f, 0, 0.8f);
                }
            }
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal") + extraspeed, rb.velocity.y);
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

        Vector2 location = new Vector2(transform.position.x - 0.50f, transform.position.y - 0.75f);
        RaycastHit2D hit = Physics2D.Raycast(location, Vector2.right, 1);
        Debug.DrawRay(location,Vector2.right);
        Debug.Log(hit.collider);

        if ((hit.collider != null) && (hit.collider.tag != "Player"))
        {
            grounded = true;
            Debug.Log(hit.collider.name);
        }
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