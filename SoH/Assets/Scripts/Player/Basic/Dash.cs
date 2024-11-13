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

    float cth;
    float deth;
    bool dashed;
    GamepadControls gamepadControls;
    Movement mv;

    private void Awake()
    {
        gamepadControls = GetComponent<GamepadControls>();
        mv = GetComponent<Movement>();
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
                    
                    if (GetComponent<CEDrainage>().cE < GetComponent<CEDrainage>().maxCE / 2) GetComponent<CEDrainage>().GainCE(1);
                }
            }
        }

        if ((deth != 0) && (Time.time - deth > dashtime))
        {
            mv.dspeed = 0;
            dashing = false;
            deth = 0;
        }

        if ((cth != 0) && (Time.time - cth > dashcooldown))
        {
            dashable = true;
            cth = 0;
        }
    }

    private void Update()
    {
        if (dashable && (Input.GetKey(KeyCode.LeftControl) || gamepadControls.dashing) && !stick && !screaming && (GetComponent<ForcesOnObject>().Force.y == 0) && !dashed && !GetComponent<Crouching>().isCrouching && !GetComponent<BlocksOnObject>().isBlocked)
        {
            GetComponent<MakeSound>().AddTime(soundTime);
            GetComponent<CEDrainage>().LoseCE(cost);
            GetComponent<CEProduce>().delayAmount = Mathf.Max(GetComponent<CEProduce>().delayAmount, cEDelay);
            dashable = false;
            dashing = true;
            dashed = true;

            for (int i = 1; i < cost + 1; i++) reloadTimes.Add(Time.time + reloadTime / cost * i);

            reloadTimes.Add(Time.time);

            if (GetComponent<SpriteRenderer>().flipX) mv.dspeed = -dashspeed;
            else mv.dspeed = dashspeed;

            deth = Time.time;
            cth = Time.time;
        }
        else if (dashable && (Input.GetKey(KeyCode.LeftControl) || gamepadControls.dashing) && !stick && !screaming && (GetComponent<ForcesOnObject>().Force == Vector2.zero) && !GetComponent<Potion>().drinking && !dashed && GetComponentInChildren<CrouchingDetection>().isSafe && GetComponent<Crouching>().isCrouching) GetComponent<Crouching>().Crouch();
        else if (!Input.GetKey(KeyCode.LeftControl) && !gamepadControls.dashing) dashed = false;
    }
}