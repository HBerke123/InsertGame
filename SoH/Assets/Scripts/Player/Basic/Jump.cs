using UnityEngine;
using System.Collections.Generic;

public class Jump : MonoBehaviour
{
    readonly List<float> reloadTimes = new();
    public MenuOpener menuOpener;
    public bool screaming;
    public bool stick;
    public float soundTime;
    public float jumpforce;
    public float jumptime;
    public float cEDelay;
    public float cost;
    public float reloadTime;
    float maxspeed;
    float stime;
    Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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

    void Update()
    {
        if (!menuOpener.isMenuOpen)
        {
            if (Input.GetKeyDown(KeyCode.Space) && this.GetComponentInChildren<GroundDetection>().detected && !stick && (this.GetComponent<ForcesOnObject>().Force == Vector2.zero) && this.GetComponentInChildren<CrouchingDetection>().isSafe)
            {
                this.GetComponent<CEDrainage>().LoseCE(cost);
                this.GetComponent<Crouching>().UnCrouch();
                this.GetComponent<MakeSound>().AddTime(soundTime);
                this.GetComponent<CEProduce>().delayAmount = Mathf.Max(this.GetComponent<CEProduce>().delayAmount, cEDelay);
                stime = Time.time;
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

                for (int i = 1; i < cost + 1; i++)
                {
                    reloadTimes.Add(Time.time + reloadTime / cost * i);
                }
            }

            if (Input.GetKey(KeyCode.Space) && (Time.time - stime < jumptime) && !stick && !screaming)
            {
                if (rb.velocity.y > maxspeed)
                {
                    maxspeed = rb.velocity.y;
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, maxspeed * jumptime - (Time.time - stime));
                }
            }
        }
    }
}
