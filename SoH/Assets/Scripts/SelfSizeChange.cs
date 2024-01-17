using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSizeChange : MonoBehaviour
{
    public GameObject ray;
    float t = 0;
    Movement movement;
    RaycastHit2D target;
    Vector3 maxscale;
    Vector3 minscale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(SelfSchange(-1));
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(SelfSchange(1));
        }
    }
    IEnumerator SelfSchange(int value, int lastvalue = 0)
    {
        if (value == -1)
        {
            if (lastvalue != -1) t = 0;
            if (target.transform.localScale == Vector3.zero)
            {
                Destroy(target.collider.gameObject);
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
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(SelfSchange(-1, value));
        }
        else if (Input.GetKey(KeyCode.T))
        {
            StartCoroutine(SelfSchange(1, value));
        }
    }
}

