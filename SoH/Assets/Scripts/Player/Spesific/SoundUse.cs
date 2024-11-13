using System.Collections.Generic;
using UnityEngine;

public class SoundUse : MonoBehaviour
{
    readonly List<float> reloadTimes = new();

    public float maxCost;
    public float minCost;
    public float maxRegainTime;
    public float minRegainTime;
    public float holdtime;
    public float cooldown;
    public float maxDelayTime;
    public float minDelayTime;
    public bool started;

    float th;
    float cth;
    bool sounded;
    bool ready = true;
    int direction = 1;
    GamepadControls gamepadControls;

    private void Awake() => gamepadControls = GetComponent<GamepadControls>();

    private void FixedUpdate()
    {
        for (int i = 0; i < reloadTimes.Count; i++) if (Time.time > reloadTimes[i])
        {
            reloadTimes.RemoveAt(i);

            if (GetComponentInParent<CEDrainage>().cE < GetComponentInParent<CEDrainage>().maxCE / 2) GetComponentInParent<CEDrainage>().GainCE(1);
        }

        if ((cth != 0) && (Time.time - cth > cooldown))
        {
            ready = true;
            cth = 0;
        }
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1) direction = 1;
        else if (Input.GetAxisRaw("Horizontal") == -1) direction = 3;

        if ((Input.GetKey(KeyCode.Q) || gamepadControls.soundInfluence) && !sounded && (th == 0) && ready && !GetComponent<GunShot>().started && !GetComponentInParent<BlocksOnObject>().isBlocked && GetComponentInParent<Crouching>().GetComponentInChildren<CrouchingDetection>().isSafe)
        {
            if (GetComponentInParent<Crouching>().isCrouching) GetComponentInParent<Crouching>().Crouch();

            sounded = true;
            GetComponentInParent<Movement>().aiming = true;
            started = true;
            ready = false;
            th = Time.time;
        }

        if (((!Input.GetKey(KeyCode.Q) && !gamepadControls.soundInfluence) || (Time.time - th >= holdtime)) && (th > 0))
        {
            GetComponentInParent<Movement>().aiming = false;
            started = false;

            if (Time.time - th > holdtime)
            {
                GetComponent<SoundInfluence>().SendWave(direction, true);
                GetComponentInParent<CEDrainage>().LoseCE(maxCost);
                GetComponentInParent<CEProduce>().delayAmount = Mathf.Max(GetComponentInParent<CEProduce>().delayAmount, maxDelayTime);

                for (int i = 1; i < maxCost + 1; i++) reloadTimes.Add(Time.time + maxRegainTime / maxCost * i);
            }
            else
            {
                GetComponent<SoundInfluence>().SendWave(direction, false);
                GetComponentInParent<CEDrainage>().LoseCE(minCost);
                GetComponentInParent<CEProduce>().delayAmount = Mathf.Max(GetComponentInParent<CEProduce>().delayAmount, minDelayTime);

                for (int i = 1; i < minCost + 1; i++) reloadTimes.Add(Time.time + minRegainTime / minCost * i);
            }

            th = 0;
            cth = Time.time;
        }

        if (!Input.GetKey(KeyCode.Q) && !gamepadControls.soundInfluence) sounded = false;
    }
}