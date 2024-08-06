using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public List<float> reloadTimes = new();
    public float soundTime;
    public float dashspeed;
    public float dashcooldown;
    public float dashtime;
    public float reloadTime;
    public float cEDelay;
    public bool dashable = true;
    public bool stick;
    public bool screaming;
    public bool dashing;
    public int cost;
    bool dashed;
    GamepadControls gamepadControls;
    Movement mv;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
        mv = this.GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        if (reloadTimes.Count != 0)
        {
            for (int i = 0; i < reloadTimes.Count; i++)
            {
                if (Time.time > reloadTimes[i])
                {
                    reloadTimes.RemoveAt(i);
                    
                    if (this.GetComponent<CEDrainage>().cE < this.GetComponent<CEDrainage>().maxCE / 2)
                    {
                        this.GetComponent<CEDrainage>().GainCE(1);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (dashable && (Input.GetKeyDown(KeyCode.LeftControl) || gamepadControls.dashing) && !stick && !screaming && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && !this.GetComponent<Potion>().drinking && !dashed)
        {
            if (this.GetComponent<Crouching>().isCrouching)
            {
                this.GetComponent<Crouching>().Crouch();
            }

            this.GetComponent<MakeSound>().totalSoundTime = Mathf.Max(soundTime, this.GetComponent<MakeSound>().totalSoundTime);
            this.GetComponent<CEDrainage>().LoseCE(cost);
            this.GetComponent<CEProduce>().delayAmount = Mathf.Max(this.GetComponent<CEProduce>().delayAmount, cEDelay);
            dashable = false;
            dashing = true;
            dashed = true;

            for (int i = 1; i < cost + 1; i++)
            {
                reloadTimes.Add(Time.time + reloadTime / cost * i);
            }

            reloadTimes.Add(Time.time);
            if (this.GetComponent<SpriteRenderer>().flipX) mv.dspeed = -dashspeed;
            else mv.dspeed = dashspeed;
            StartCoroutine(Dashend());
            StartCoroutine(Cooldown());
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || !gamepadControls.dashing)
        {
            dashed = false;
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
