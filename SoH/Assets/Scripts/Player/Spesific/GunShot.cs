using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public List<GameObject> lastBombs = new List<GameObject>();
    public GameObject PreBombShower;
    public GameObject Bomb;
    public GameObject SoundWave;
    public float soundTime;
    public float damage;
    public float forcePower;
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
    bool explosed;
    bool triattack;
    bool reloading;
    float th = 0;
    float hth = 0;

    void FixedUpdate()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && (this.GetComponentInParent<PrimaryItems>().itemEquipped == "Gun"))
        {
            explosed = true;

            for (int i = 0; i < lastBombs.Count; i++)
            {
                lastBombs[i].GetComponent<BombExplode>().Explode();
            }
        }

        if ((this.GetComponentInParent<PrimaryItems>().itemEquipped == "Gun") && !reloading)
        {  
            if (lastBombs.Count == 0)
            {
                if (Input.GetMouseButtonDown(0) && (ammo > 0) && (Time.time - th > cooldown))
                {
                    explosed = false;
                    triattack = false;
                    hth = Time.time;
                    PreBombShower.GetComponent<ShowPreBombs>().ShowBombs(triattack);
                }
                else if (Input.GetMouseButtonDown(1) && (ammo == 3) && (Time.time - th > cooldown))
                {
                    explosed = false;
                    triattack = true;
                    hth = Time.time;
                    PreBombShower.GetComponent<ShowPreBombs>().ShowBombs(triattack);
                }
            }
            
            if (!explosed)
            {
                if ((Input.GetMouseButtonUp(0) || (Time.time - hth > htime)) && (hth != 0) && (ammo > 0) && (Time.time - th > cooldown) && !triattack)
                {
                    this.GetComponentInParent<MakeSound>().AddTime(soundTime);
                    PreBombShower.GetComponent<ShowPreBombs>().StopShowing();
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
                else if ((Input.GetMouseButtonUp(1) || (Time.time - hth > htime)) && (hth != 0) && (ammo == 3) && (Time.time - th > cooldown) && triattack)
                {
                    this.GetComponentInParent<MakeSound>().AddTime(soundTime);
                    PreBombShower.GetComponent<ShowPreBombs>().StopShowing();

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
    }

    void SendBomb(int direction, float bombforce)
    {
        GameObject SBox = Instantiate(Bomb, this.transform.position, new Quaternion(0, 0, 0, 0));
        lastBombs.Add(SBox);

        if (this.GetComponentInParent<SpriteRenderer>().flipX)
        {
            SBox.GetComponent<Rigidbody2D>().AddForce(new Vector2(-minbombforce + -bombforce * (maxbombforce - minbombforce), -5 + 5 * direction), ForceMode2D.Impulse);
        }
        else 
        { 
            SBox.GetComponent<Rigidbody2D>().AddForce(new Vector2(minbombforce + bombforce * (maxbombforce - minbombforce), -5 + 5 * direction), ForceMode2D.Impulse);
        }

        SBox.GetComponent<BombExplode>().TotalTime = ttime;
        SBox.GetComponent<BombExplode>().minsize = minsize;
        SBox.GetComponent<BombExplode>().maxsize = maxsize;
        SBox.GetComponent<BombExplode>().ttime = twtime;
        SBox.GetComponent<BombExplode>().SoundWave = SoundWave;
        SBox.GetComponent<BombExplode>().forcePower = forcePower;
        SBox.GetComponent<BombExplode>().damageAmount = damage;
        ammo--;

        if (ammo == 0) 
        {
            StartCoroutine(Reload());
        };
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
