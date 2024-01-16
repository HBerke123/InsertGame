using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public GameObject ray;
    bool rayed = false;
    float t = 0;
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
                minscale = new Vector3(hit.transform.localScale.x - 1, hit.transform.localScale.y - 1, 0);
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
                    StartCoroutine(Schange(-1));
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    StartCoroutine(Schange(1));
                }
            }
            else
            {
                rayed = false;
                ray.transform.localScale = Vector3.zero;
            }
        }
    }

    IEnumerator Schange(int value, int lastvalue = 0)
    {
        if (value == -1) {
            if (lastvalue != -1) t = 0;
            if (target.transform.localScale == Vector3.zero)
            {
                Destroy(target.collider.gameObject);
                rayed = false;
                ray.transform.localScale = Vector3.zero;
            }
            target.transform.localScale = Vector3.Lerp(target.transform.localScale, minscale, t);
        }
        else
        {
            if (lastvalue != 1) t = 0;
            target.transform.localScale = Vector3.Lerp(target.transform.localScale, maxscale, t);
        }
        yield return new WaitForSeconds(1f);
        t += 0.1f;
        if (Input.GetKey(KeyCode.Z))
        {
            StartCoroutine(Schange(-1, value));
        }
        else if (Input.GetKey(KeyCode.X))
        {
            StartCoroutine(Schange(1, value));
        }
    }
}