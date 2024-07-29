using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float soundTime;
    public float dashspeed;
    public float dashcooldown ;
    public float dashtime;
    public bool dashable = true;
    public bool stick;
    public bool screaming;
    public bool dashing;
    public int cecost;
    Movement mv;

    private void Start()
    {
        mv = this.GetComponent<Movement>();
    }

    private void Update()
    {
        if (dashable && Input.GetKeyDown(KeyCode.LeftControl) && !stick && !screaming && !this.GetComponent<Crouching>().isCrouching && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero))
        {
            this.GetComponent<MakeSound>().totalSoundTime = Mathf.Max(soundTime, this.GetComponent<MakeSound>().totalSoundTime);
            this.GetComponent<CEDrainage>().LoseCE(cecost);
            dashable = false;
            dashing = true;
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
