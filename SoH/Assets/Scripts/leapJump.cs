using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int timeHeld = 0;
    public float jumpforce;
    public bool moveable = true;
    public bool grounded;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) && grounded && rb.velocity.y <= jumpforce) {
            for (int i = 0, i> -1) {
                float counter = 1;
                if (Input.GetKey(KeyCode.Space) = false)
                {

                }
            }
        }
    }
}
