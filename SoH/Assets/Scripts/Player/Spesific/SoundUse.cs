using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUse : MonoBehaviour
{
    public float holdtime;
    public float cooldown;
    float th;
    bool ready = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (th == 0) && ready)
        {
            ready = false;
            th = Time.time;
        }

        if ((Input.GetKeyUp(KeyCode.Q) || (Time.time - th >= holdtime)) && (th > 0))
        {
            if (Time.time - th < holdtime)
            {
                if (this.GetComponentInParent<SpriteRenderer>().flipX) this.GetComponent<SoundInfluence>().SendWave(-1, false);
                else this.GetComponent<SoundInfluence>().SendWave(1, false);
            }
            else
            {
                if (this.GetComponentInParent<SpriteRenderer>().flipX) this.GetComponent<SoundInfluence>().SendWave(-1, true);
                else this.GetComponent<SoundInfluence>().SendWave(1, true);
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
