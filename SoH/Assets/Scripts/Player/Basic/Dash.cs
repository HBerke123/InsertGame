using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float soundTime;
    public float dashspeed;
    public float dashcooldown;
    public float dashtime;
    public float reloadTime;
    public float reloadCount;
    public bool dashable = true;
    public bool stick;
    public bool screaming;
    public bool dashing;
    public int cecost;
    public List<float> reloadTimes = new List<float>();
    Movement mv;

    private void Start()
    {
        mv = this.GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        if (reloadTimes.Count != 0)
        {
            for (int i = 0; i < reloadTimes.Count; i++)
            {
                if (Time.time - reloadTimes[i] > reloadTime / reloadCount)
                {
                    this.GetComponent<CEDrainage>().GainCE(1);
                    reloadTimes.Remove(reloadTimes[i]);
                }
            }
        }
    }

    private void Update()
    {
        if (dashable && Input.GetKeyDown(KeyCode.LeftControl) && !stick && !screaming && !this.GetComponent<Crouching>().isCrouching && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            this.GetComponent<MakeSound>().totalSoundTime = Mathf.Max(soundTime, this.GetComponent<MakeSound>().totalSoundTime);
            this.GetComponent<CEDrainage>().LoseCE(cecost);
            dashable = false;
            dashing = true;

            for (int i = 1; i < reloadCount + 1; i++)
            {
                reloadTimes.Add(Time.time + reloadTime / reloadCount * i);
            }

            reloadTimes.Add(Time.time);
            if (this.GetComponent<SpriteRenderer>().flipX) mv.dspeed = -dashspeed;
            else mv.dspeed = dashspeed;
            StartCoroutine(Dashend());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Dashend()
    {
        yield return new WaitForSecondsRealtime(dashtime);
        mv.dspeed = 0;
        dashing = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(dashcooldown);
        dashable = true;
    }
}
