using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject rope;

    private void Update()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized * 10;
        dir.z = 0;
        
        
        if (Input.GetKeyDown(KeyCode.E)) { 
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, dir);
            Debug.DrawRay(this.transform.position, hit.transform.position);

            if ((hit.collider != null) && (hit.collider.tag == "Hookable"))
            {
                rope.transform.localScale = new Vector3(0, 0, Mathf.Sqrt(Mathf.Pow(Mathf.Abs(hit.transform.position.x - this.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(hit.transform.position.y - this.transform.position.y), 2)));
            }
        }
    }
}
