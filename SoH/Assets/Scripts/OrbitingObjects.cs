using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingObjects : MonoBehaviour
{
    bool matched = false;
    Movement movement;
    RaycastHit2D target;
    DistanceJoint2D gdj;

    private void Start()
    {
        movement = this.GetComponent<Movement>();
    }

    private void Update()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized * 10;
        dir.z = 0;

        if (Input.GetKeyDown(KeyCode.F))
        {
            LayerMask mask = LayerMask.GetMask("Orbitables");
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, 4, mask);

            if ((hit.collider != null) && hit.collider.CompareTag("Orbitable") && !matched)
            {
                DistanceJoint2D dj = gameObject.AddComponent(typeof(DistanceJoint2D)) as DistanceJoint2D;
                dj.enableCollision = true;
                dj.maxDistanceOnly = true;
                dj.connectedBody = hit.collider.GetComponent<Rigidbody2D>();
                if (dj.distance <= 4)
                {
                    dj.autoConfigureDistance = false;
                    gdj = dj;
                    target = hit;
                    matched = true;
                }
                else Destroy(dj);
            }
            else
            {
                matched = false;
                movement.moveable = true;
                Destroy(gdj);
            }
        }

        if (matched)
        {
            movement.moveable = movement.grounded;
        }
    }
}