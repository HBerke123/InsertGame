using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public GameObject ray;
    bool rayed = false;
    Movement movement;
    RaycastHit2D target;
    Vector3 maxscale;
    Vector3 minscale;

    private void Start()
    {
        movement = this.GetComponent<Movement>();
    }

    private void Update()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized * 10;
        dir.z = 0;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LayerMask mask = LayerMask.GetMask("Changeable");
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir, 4, mask);

            if ((hit.collider != null) && (hit.collider.tag == "Changeable") && !(rayed))
            {
                maxscale = new Vector3(hit.transform.localScale.x + 1, hit.transform.localScale.y + 1, 0);
                maxscale = new Vector3(hit.transform.localScale.x + 1, hit.transform.localScale.y + 1, 0);
                target = hit;
                rayed = true;
            }
            else
            {
                ray.transform.localScale = Vector3.zero;
                rayed = false;
            }
        }

        if (rayed)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(this.transform.position.x - target.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.y - target.transform.position.y), 2));
            if (distance <= 4) { 
                ray.transform.localScale = new Vector3(0, 0, distance);
                ray.transform.position = this.transform.position;
                ray.transform.LookAt(target.transform);
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    target.transform.localScale = maxscale;
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    target.transform.localScale = minscale;
                    if (minscale == new Vector3(0, 0, 0))
                    {
                        Destroy(target.collider);
                        rayed = false;
                    }
                }
            }
        }
    }
}