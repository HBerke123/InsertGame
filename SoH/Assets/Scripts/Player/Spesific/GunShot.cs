using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject[] PreBombs;
    public GameObject Bomb;
    public GameObject SoundWave;
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

    void Update()
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

            if (Input.GetMouseButtonUp(0) && (ammo > 0) && (Time.time - th > cooldown))
            {
                SendBomb(1);
                th = Time.time;
            }
            else if (Input.GetMouseButtonUp(1) && (ammo == 3) && (Time.time - th > cooldown))
            {
                for (int i = 0; i < 3; i++) SendBomb(i);
                th = Time.time;
            }
        }
    }

    void SendBomb(int direction)
    {
        GameObject SBox = Instantiate(Bomb, this.transform.position, new Quaternion(0, 0, 0, 0));
        if (this.GetComponentInParent<SpriteRenderer>().flipX) SBox.GetComponent<Rigidbody2D>().AddForce(new Vector2(-maxbombforce, -5 + 5 * direction), ForceMode2D.Impulse);
        else SBox.GetComponent<Rigidbody2D>().AddForce(new Vector2(maxbombforce, -5 + 5 * direction), ForceMode2D.Impulse);
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
