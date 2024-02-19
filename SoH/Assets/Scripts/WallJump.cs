using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    Movement mv;
    public int rotation;
    public bool hold;
    private void Start()
    {
        mv = this.GetComponent<Movement>();
    }

    private void Update()
    {
        if (hold == false)
        {
            LayerMask mask = LayerMask.GetMask("Ground");

            Vector3 location = new Vector3(transform.position.x - 0.75f, transform.position.y + 0.5f, 0);
            RaycastHit2D hit = Physics2D.Raycast(location, Vector3.down, 1, mask);

        
            if (hit.collider != null) {
                mv.extracondition[1] = true;
                rotation = -1;
                hold = true;
                }
            else mv.extracondition[1] = false;
        

            location = new Vector3(transform.position.x + 0.75f, transform.position.y + 0.5f, 0);
            hit = Physics2D.Raycast(location, Vector3.down, 1, mask);
                
            if (hit.collider != null)
            {
                mv.extracondition[1] = true;
                rotation = 1;
                hold = true;
            }
        }
    }

    public IEnumerator OnLeave()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        hold = false;
        mv.onWallJump();

    }

    public IEnumerator OnLeaveOff()
    {
        yield return new WaitForSeconds(1);
        hold = false;
    }
}
