using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject rope;
    bool matched = false;
    Movement movement;
    RaycastHit2D target;
    DistanceJoint2D gdj;
    Rigidbody2D rb;

    private void Start() {
        movement = this.GetComponent<Movement>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized * 10;
        dir.z = 0;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 vel = rb.velocity;
            LayerMask mask = LayerMask.GetMask("Hookables");
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, 4, mask);

            if ((hit.collider != null) && hit.collider.CompareTag("Hookable") && !matched)
            {
                DistanceJoint2D dj = gameObject.AddComponent(typeof(DistanceJoint2D)) as DistanceJoint2D;
                dj.enableCollision = true;
                dj.maxDistanceOnly = true;
                dj.connectedBody = hit.collider.GetComponent<Rigidbody2D>();
                if (dj.distance <= 4)
                {
                    movement.speed = 10;
                    this.GetComponent<Renderer>().material.color = new Color(1.1f, 1.1f, 0);
                    rb.velocity = vel;
                    dj.distance = 4;
                    dj.autoConfigureDistance = false;
                    gdj = dj;
                    target = hit;
                    matched = true;
                }
                else Destroy(dj);
            }
            else
            {
                rope.transform.localScale = Vector3.zero;
                matched = false;
                movement.moveable = true;
                Destroy(gdj);
            }
        }

        if (matched)
        {
            rope.transform.localScale = new Vector3(0, 0, Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - target.transform.position.x) , 2)  +  Mathf.Pow(Mathf.Abs(this.transform.position.y - target.transform.position.y) , 2)));
            rope.transform.position = this.transform.position;
            rope.transform.LookAt(target.transform);
            movement.moveable = movement.grounded;
        }
    }
}