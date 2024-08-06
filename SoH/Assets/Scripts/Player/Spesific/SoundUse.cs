using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SoundUse : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public TimeControlSlow timeSlower;
    public GameObject arrow;
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
    bool sounded;
    bool ready = true;
    int direction;
    GamepadControls gamepadControls;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < reloadTimes.Count; i++)
        {
            if (Time.time > reloadTimes[i])
            {
                reloadTimes.RemoveAt(i);

                if (this.GetComponentInParent<CEDrainage>().cE < this.GetComponentInParent<CEDrainage>().maxCE / 2)
                {
                    this.GetComponentInParent<CEDrainage>().GainCE(1);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            arrow.transform.localPosition = Vector3.right * 1.725f;
            direction = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            arrow.transform.localPosition = Vector3.left * 1.725f;
            direction = 3;
        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            arrow.transform.localPosition = Vector3.up * 3.9f;
            direction = 0;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            arrow.transform.localPosition = Vector3.down * 1;
            direction = 2;
        }

        if ((Input.GetKey(KeyCode.Q) || gamepadControls.soundInfluence) && !sounded && (th == 0) && ready && !this.GetComponent<GunShot>().started && !this.GetComponent<ScreamUse>().screaming && !this.GetComponent<SwordAttack>().ready && !this.GetComponentInParent<BlocksOnObject>().isBlocked && this.GetComponentInParent<Crouching>().GetComponentInChildren<CrouchingDetection>().isSafe && !this.GetComponentInParent<Potion>().drinking)
        {
            if (this.GetComponentInParent<Crouching>().isCrouching)
            {
                this.GetComponentInParent<Crouching>().Crouch();
            }

            sounded = true;
            arrow.SetActive(false);
            timeSlower.StartSlowMotion();
            this.GetComponentInParent<Movement>().aiming = true;
            started = true;
            ready = false;
            th = Time.time;
        }

        if ((Input.GetKeyUp(KeyCode.Q) || !gamepadControls.soundInfluence || (Time.time - th >= holdtime)) && (th > 0))
        {
            this.GetComponentInParent<Movement>().aiming = false;
            timeSlower.StopSlowMotion();
            arrow.SetActive(true);
            started = false;

            if (Time.time - th > holdtime)
            {
                this.GetComponent<SoundInfluence>().SendWave(direction, true);
                this.GetComponentInParent<CEDrainage>().LoseCE(maxCost);
                this.GetComponentInParent<CEProduce>().delayAmount = Mathf.Max(this.GetComponentInParent<CEProduce>().delayAmount, maxDelayTime);

                for (int i = 1; i < maxCost + 1; i++)
                {
                    reloadTimes.Add(Time.time + maxRegainTime / maxCost * i);
                }
            }
            else
            {
                this.GetComponent<SoundInfluence>().SendWave(direction, false);
                this.GetComponentInParent<CEDrainage>().LoseCE(minCost);
                this.GetComponentInParent<CEProduce>().delayAmount = Mathf.Max(this.GetComponentInParent<CEProduce>().delayAmount, minDelayTime);

                for (int i = 1; i < minCost + 1; i++)
                {
                    reloadTimes.Add(Time.time + minRegainTime / minCost * i);
                }
            }

            th = 0;
            StartCoroutine(Cooldown());
        }

        if (Input.GetKeyUp(KeyCode.Q) || !gamepadControls.soundInfluence)
        {
            sounded = false;
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        ready = true;
    }
}
