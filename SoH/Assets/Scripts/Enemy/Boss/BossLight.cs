using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLight : MonoBehaviour
{
    public float bigScale;
    public float appearTime;
    public int num;
    float th;

    private void Start()
    {
        th = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - th > appearTime)
        {
            if (num == 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + bigScale / 2 - this.transform.localScale.y / 2, 0);
            }
            else if (num == 1)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - bigScale / 2 + this.transform.localScale.y / 2, 0);
            }

            this.transform.localScale = new Vector3(this.transform.localScale.x, bigScale, 0);
            this.GetComponent<DamagePlayer>().canNotDamage = false;
            Destroy(this);
        }
    }
}