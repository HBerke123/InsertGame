using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject[] PreBombs;
    public GameObject Bomb;
    public GameObject SoundWave;
    public float htime;
    public float ttime;
    public float reloadtime;
    public float ceregaintime;
    public float minbombforce;
    public float maxbombforce;
    public float cooldown;
    public float minsize;
    public float maxsize;
    public float twtime;
    public int cecost;
    int ammo = 3;
    bool reloading = false;
    float th = 0;
    float hth = 0;

    void FixedUpdate()
    {
        if ((this.GetComponentInParent<PrimaryItems>().itemEquipped == "Gun") && !reloading)
        {
            if (Input.GetMouseButtonDown(0) && (ammo > 0) && (Time.time - th > cooldown))
            {
                hth = Time.time;
            }
            else if (Input.GetMouseButtonDown(1) && (ammo == 3) && (Time.time - th > cooldown))
            {
                hth = Time.time;
            }

            if (((Input.GetMouseButtonUp(0)) || (Time.time - hth > htime)) && (hth != 0) && (ammo > 0) && (Time.time - th > cooldown))
            {
                if (Time.time - hth > htime)
                {
                    SendBomb(1, 1);
                }
                else
                {
                    SendBomb(1, (Time.time - hth) / htime);
                }
                th = Time.time;
                hth = 0;
            }
            else if (((Input.GetMouseButtonUp(1)) || (Time.time - hth > htime)) && (hth != 0) && (ammo == 3) && (Time.time - th > cooldown))
            {
                if (Time.time - hth > htime)
                {
                    for (int i = 0; i < 3; i++) SendBomb(i, 1);
                }
                else
                {
                    for (int i = 0; i < 3; i++) SendBomb(i, (Time.time - hth) / htime);
                }
                
                th = Time.time;
                hth = 0;
            }
        }
    }

    void SendBomb(int direction, float bombforce)
    {
        GameObject SBox = Instantiate(Bomb, this.transform.position, new Quaternion(0, 0, 0, 0));
        if (this.GetComponentInParent<SpriteRenderer>().flipX) SBox.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bombforce, -5 + 5 * direction), ForceMode2D.Impulse);
        else SBox.GetComponent<Rigidbody2D>().AddForce(new Vector2(minbombforce + bombforce * (maxbombforce - minbombforce), -5 + 5 * direction), ForceMode2D.Impulse);
        SBox.GetComponent<BombExplode>().TotalTime = ttime;
        SBox.GetComponent<BombExplode>().minsize = minsize;
        SBox.GetComponent<BombExplode>().maxsize = maxsize;
        SBox.GetComponent<BombExplode>().ttime = twtime;
        SBox.GetComponent<BombExplode>().SoundWave = SoundWave;
        ammo--;
        if (ammo == 0) StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        reloading = true;
        this.GetComponentInParent<CEDrainage>().LoseCE(cecost);
        StartCoroutine(RegainCE());
        yield return new WaitForSecondsRealtime(reloadtime);
        reloading = false;
        th = 0;
        ammo = 3;
    }

    IEnumerator RegainCE()
    {
        for (int i = 0; i < cecost; i++)
        {
            yield return new WaitForSecondsRealtime(ceregaintime / cecost);
            this.GetComponentInParent<CEDrainage>().GainCE(1);
        }
    }
}
