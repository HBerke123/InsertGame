using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUse : MonoBehaviour
{
    public float holdtime;
    public float cooldown;
    float th;
    bool ready = true;
    int direction;

    private void Update()
    {
        float cursorx = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.GetComponentInParent<Transform>().position.x;
        float cursory = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.GetComponentInParent<Transform>().position.y;
        if (Mathf.Abs(cursorx) >= Mathf.Abs(cursory))
        {
            if (Mathf.Abs(cursorx) / cursorx == 1)
            {
                direction = 1;
            }
            else
            {
                direction = 3;
            }
        }
        else
        {
            if (Mathf.Abs(cursory) / cursory == 1)
            {
                direction = 0;
            }
            else
            {
                direction = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && (th == 0) && ready)
        {
            ready = false;
            th = Time.time;
        }

        if ((Input.GetKeyUp(KeyCode.Q) || (Time.time - th >= holdtime)) && (th > 0))
        {
            if (Time.time - th < holdtime)
            {
                this.GetComponent<SoundInfluence>().SendWave(direction, false);
            }
            else
            {
                this.GetComponent<SoundInfluence>().SendWave(direction, true);
            }
            th = 0;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        ready = true;
    }
}
