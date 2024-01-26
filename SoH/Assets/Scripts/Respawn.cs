using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.y < -30)
        {
            if (this.CompareTag("Player")) {
                this.transform.position = new Vector3(0f, 0f, 0f);
            }
            else
            {
                this.transform.position = new Vector3(180f, 0f, 0f);
            }
        }
    }
}
