using System.Collections;
using UnityEngine;

public class SoundUse : MonoBehaviour
{
    public TimeControlSlow timeSlower;
    public GameObject arrow;
    public float maxCost;
    public float minCost;
    public float holdtime;
    public float cooldown;
    public bool started;
    float th;
    bool ready = true;
    int direction;

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

        if (Input.GetKeyDown(KeyCode.Q) && (th == 0) && ready && !this.GetComponent<GunShot>().started && !this.GetComponent<ScreamUse>().screaming && !this.GetComponent<SwordAttack>().ready && !this.GetComponentInParent<BlocksOnObject>().isBlocked)
        {
            arrow.SetActive(false);
            timeSlower.StartSlowMotion();
            this.GetComponentInParent<Movement>().aiming = true;
            started = true;
            ready = false;
            th = Time.time;
        }

        if ((Input.GetKeyUp(KeyCode.Q) || (Time.time - th >= holdtime)) && (th > 0))
        {
            this.GetComponentInParent<Movement>().aiming = false;
            timeSlower.StopSlowMotion();
            arrow.SetActive(true);
            started = false;

            if (Time.time - th > holdtime)
            {
                this.GetComponent<SoundInfluence>().SendWave(direction, true);
                this.GetComponentInParent<CEDrainage>().LoseCE(maxCost);
            }
            else
            {
                this.GetComponent<SoundInfluence>().SendWave(direction, false);
                this.GetComponentInParent<CEDrainage>().LoseCE(minCost);
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
